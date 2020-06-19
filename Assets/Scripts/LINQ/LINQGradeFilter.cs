using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

//The quiz grades should be between 0 – 100. 
//Filter through the quiz grades, create a new collection of only passing grades > 80 
public class LINQGradeFilter : MonoBehaviour
{
    private int[] grades = {90, 80, 70, 60, 65};
    public int passThreshold = 80;
    private List<int> passedGrades = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        var passGrades = grades.Where(grade => grade >= passThreshold);
        foreach(var grade in passGrades)
        {
            Debug.Log("Passing Grades" + grade);
        }
    }
}

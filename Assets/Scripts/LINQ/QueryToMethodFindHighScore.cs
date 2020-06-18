using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class QueryToMethodFindHighScore : MonoBehaviour
{
    int[] scores = new int[] { 91, 93, 82, 62 };
    [SerializeField] private int highScoreThreshold = 80;

    // Start is called before the first frame update
    void Start()
    {
        //query expression from https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
        var scoreQuery =
            from score in scores
            where score > highScoreThreshold
            select score; //required by query 

        //method expression equivalent
        var scoreQueryMethod = scores.Where(score => score > highScoreThreshold);

        //method expression equivalent
        foreach (var highScore in scoreQueryMethod)
        {
            Debug.Log("High Score: " + highScore);
        }
    }
}

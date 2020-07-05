using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public string[] shapes = { "circle", "square", "triangle", "octagon"}; //fixed in length
    public string[] moreShapes = new string[4];

    //tedious implementation without array
    //public string nameOne = "circle";
    //public string nameTwo = "square";
    //public string nameThree = "triangle";
    //public string nameFour = "octagon";

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < shapes.Length; i++)
        {
            shapes[i] = shapes[i].ToUpper();
            Debug.Log(shapes[i]);
        }
        //tedious implementation without array
        //nameOne = nameOne.ToUpper();
        //nameTwo = nameTwo.ToUpper();
        //nameThree = nameThree.ToUpper();
        //nameFour = nameFour.ToUpper();
    }
}

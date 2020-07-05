using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    //array
    public string[] shapesArray = { "circle", "square", "triangle", "octagon"}; //fixed in length
    //public string[] moreShapes = new string[4];

    //list
    public List<string> shapesList;
    public List<Shape> gameShapesList;

    //tedious implementation without array / list
    //public string nameOne = "circle";
    //public string nameTwo = "square";
    //public string nameThree = "triangle";
    //public string nameFour = "octagon";

    // Start is called before the first frame update
    void Start()
    {
        //array
        for(int i = 0; i < shapesArray.Length; i++)
        {
            shapesArray[i] = shapesArray[i].ToUpper();
            Debug.Log(shapesArray[i]);
        }

        Shape octagon = gameShapesList.Find(s => s.Name == "Octagon"); //takes predicate: condition to match when searching list
        octagon.SetColor(Color.red);

        //list
        //shapesList = new List<string>();
        shapesList = new List<string> { "Hexagon", "Heptagon", "Rhombus", "Nonagon" };
        shapesList.Add("Rectangle"); //can't do this with array
        shapesList.Insert(2, "Diamond"); //add diamond at the 3rd position of the list
        shapesList.Sort(); //output list alphabetically
        for (int i = 0; i < shapesList.Count; i++)
        {
            shapesList[i] = shapesList[i].ToUpper();
            Debug.Log(shapesList[i]);
        }

        //tedious implementation without array / list
        //nameOne = nameOne.ToUpper();
        //nameTwo = nameTwo.ToUpper();
        //nameThree = nameThree.ToUpper();
        //nameFour = nameFour.ToUpper();
    }
}

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

    //dictionary
    public Dictionary<string, Shape> shapesDictionary;

    // Start is called before the first frame update
    void Start()
    {
        //array
        for(int i = 0; i < shapesArray.Length; i++)
        {
            shapesArray[i] = shapesArray[i].ToUpper();
            Debug.Log(shapesArray[i]);
        }

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

        Shape octagon = gameShapesList.Find(s => s.Name == "Octagon"); //takes predicate: condition to match when searching list
        octagon.SetColor(Color.red);

        //dictionary
        shapesDictionary = new Dictionary<string, Shape>(); //instance of dictionary
        //shapesDictionary.Add("Octagon", octagon);
        //shapesDictionary["Octagon"].SetColor(Color.green); //reference dictionary element by its key

        foreach (Shape shape in gameShapesList)
        {
            shapesDictionary.Add(shape.Name, shape);
        }
    }

    //reference each item in the dictionary using a meaningful key name
    private void SetRedByName(string shapeName)
    {
        shapesDictionary[shapeName].SetColor(Color.red);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SetRedByName("Square");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SetRedByName("Circle");
        }
    }
}

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

    //queue & stack
    public enum useQueueOrStack { useQueue, useStack };
    useQueueOrStack currentSelection;
    public Queue<Shape> shapesQueue;
    public Stack<Shape> shapesStack;

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

        //switch between queues and stacks
        currentSelection = useQueueOrStack.useStack;

        //queue: pay attention to the order elements are added
        shapesQueue = new Queue<Shape>();
        shapesQueue.Enqueue(shapesDictionary["Triangle"]);
        shapesQueue.Enqueue(shapesDictionary["Square"]);
        shapesQueue.Enqueue(shapesDictionary["Circle"]);

        //stack
        shapesStack = new Stack<Shape>();
        shapesStack.Push(shapesDictionary["Triangle"]);
        shapesStack.Push(shapesDictionary["Square"]);
        shapesStack.Push(shapesDictionary["Circle"]);
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (currentSelection)
            {
                case useQueueOrStack.useQueue:
                    if (shapesQueue.Count > 0)
                    {
                        Shape shapeToDequeue = shapesQueue.Dequeue(); //FIFO
                        shapeToDequeue.SetColor(Color.blue);
                    }
                    else
                    {
                        Debug.Log("Queue is empty");
                    }
                break;

                case useQueueOrStack.useStack:
                    if (shapesStack.Count > 0)
                    {
                        Shape shapeToPop = shapesStack.Pop(); //LIFO
                        shapeToPop.SetColor(Color.green);
                    }
                    else
                    {
                        Debug.Log("Stack is empty");
                    }
                break;
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSceneController : MonoBehaviour
{
    public List<Shape> gameShapes;
    public float secondsToWait = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SetShapesBlue());
            //SetShapesRed();
        }
    }

    private IEnumerator SetShapesBlue()
    {
        foreach (Shape shape in gameShapes)
        {
            shape.SetColor(Color.blue);
            //change colour 1 shape at a time with a slight delay between them
            yield return new WaitForSeconds(secondsToWait);
        }
    }

    private void SetShapesRed()
    {
        foreach(Shape shape in gameShapes)
        {
            shape.SetColor(Color.red);
        }
    }
}

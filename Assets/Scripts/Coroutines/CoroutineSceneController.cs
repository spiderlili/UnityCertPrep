using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSceneController : MonoBehaviour
{
    public List<Shape> gameShapes;
    public float secondsToWait = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SetShapesBlue());
            Time.timeScale = 0; //pause the game
            //SetShapesRed();
        }
    }

    private IEnumerator SetShapesBlue()
    {
        foreach (Shape shape in gameShapes)
        {
            shape.SetColor(Color.blue);
            //change colour 1 shape at a time with a slight delay between them
            //yield return new WaitForSeconds(secondsToWait); //execution of the coroutine is paused for x seconds, then resume

            //works even if the game is paused with Time.timeScale = 0;
            //useful for scenarios where you want to pause the game & have UI elements continue animating - can't do with Update()
            yield return new WaitForSecondsRealtime(secondsToWait);
            shape.SetColor(Color.white);
        }
        yield return new WaitForSecondsRealtime(1); //can yield more than once in a coroutine
        Debug.Log("just wasted a second");
    }

    private void SetShapesRed()
    {
        foreach(Shape shape in gameShapes)
        {
            shape.SetColor(Color.red);
        }
    }
}

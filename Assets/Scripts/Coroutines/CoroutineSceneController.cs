using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSceneController : MonoBehaviour
{
    public List<Shape> gameShapes;
    public float secondsToWait = 1f;
    public bool pauseGameAfterSetShapeColor = false;
    public int numberToCountTo = 10000;

    //stopping a coroutine by reference
    private Coroutine countToNumberCoroutine;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //start and stop a coroutine by reference
            countToNumberCoroutine = StartCoroutine(CountToNumber(numberToCountTo));

            //must start coroutine with a string to stop it using a string
            StartCoroutine("CountToNumber", numberToCountTo); 
            //StartCoroutine(CountToNumber(numberToCountTo));
            //CountToNumber(numberToCountTo);
            Debug.Log("Space Key Press complete");
            
            StartCoroutine(SetShapesBlue());
            if(pauseGameAfterSetShapeColor == true)
            {
                Time.timeScale = 0; //pause the game
            }
            //SetShapesRed();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            StopCoroutine(countToNumberCoroutine); //stop a coroutine by reference
            //StopCoroutine("CountToNumber"); //stop a coroutine by string
            //StopAllCoroutines();
        }
    }

    //allows coroutines to run independent of the update() method
    private IEnumerator CountToNumber(int NumberToCountTo)
    {
        for (int i = 0; i <= NumberToCountTo; i++)
        {
            Debug.Log(i);
            yield return null;
        }
    }

    //traditional method without coroutine: will result in a hang if number is too large as process has to be complete to continue
    /*
    private void CountToNumber(int NumberToCountTo)
    {
        for(int i = 0; i <= NumberToCountTo; i++)
        {
            Debug.Log(i);
        }
    }*/

    private IEnumerator SetShapesBlue()
    {
        Debug.Log("Start changing colours.");
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

        //stops coroutine
        yield return StartCoroutine(SetShapesBlue()); //keep cycling through shapes 
    }

    private void SetShapesRed()
    {
        foreach(Shape shape in gameShapes)
        {
            shape.SetColor(Color.red);
        }
    }
}

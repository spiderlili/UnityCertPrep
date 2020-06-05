using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDelegate : MonoBehaviour
{
    public delegate void ChangeColor(Color newColor);
    public ChangeColor onColorChange;

    public delegate void OnComplete(); //called when you complete a method
    public OnComplete onComplete;

    private void Start()
    {
        //onColorChange; //can't assign onColorChange to this traditional method because signatures don't match. 
        
        onColorChange = UpdateColor;
        onColorChange(Color.green);

        //onColorChange = Task; //can't assign because signatures don't match

        //onComplete = TaskFinished;
        //multicast delegates: stacking / register methods into the onComplete delegate
        onComplete += TaskFinished;
        onComplete += Task2Finished;
        onComplete += Task3Finished;

        //deregister / remove method form delegate
        onComplete -= Task3Finished;

        if(onComplete != null) //make sure onComplete delegate is not null before invoking to avoid errors
        {
            onComplete(); //call the onComplete delegate
        }
    }

    public void UpdateColor(Color newColor) // signature must match the delegate void ChangeColor with a color parameter
    {
        Debug.Log("Changing Color to: " + newColor.ToString());
    }

    public void TaskFinished()
    {
        Debug.Log("task finished");
    }

    //multicast delegates can stack on tasks
    public void Task2Finished()
    {
        Debug.Log("task 2 finished");
    }

    public void Task3Finished()
    {
        Debug.Log("task 3 finished");
    }
}

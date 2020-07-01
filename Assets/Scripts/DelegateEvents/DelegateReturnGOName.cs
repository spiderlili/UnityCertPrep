using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateReturnGOName : MonoBehaviour
{
    //create a delegate of type void (action) that has no parameters => return the game object's name
    public Action onGetName;

    private void Start()
    {
        //use a lambda to eliminate the need of a method: () => no parameters go to
        //onGetName = () => Debug.Log("Name: " + gameObject.name);

        //to add more game logic
        onGetName = () =>
        {
            Debug.Log("Name: " + gameObject.name);
            Debug.Log("More Game Logic");
        };

        //call the action delegate like a method
        onGetName(); 
    }

    //legacy way without using delegates
    /*private void GetGOName()
    {
        Debug.Log("Name: " + gameObject.name); //return name of the game object this script is on
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    protected string petName; //only those who inherits this class can modify this info

    protected virtual void Speak() //protected virtual functions allow for overwriting from any class that inherits this class
    {
        Debug.Log("Speak");
    }

    private void Start()
    {
        Speak();
    }
}

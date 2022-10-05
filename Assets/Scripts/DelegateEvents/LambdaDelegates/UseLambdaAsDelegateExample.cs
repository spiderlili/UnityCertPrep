using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseLambdaAsDelegateExample : MonoBehaviour
{
    public delegate void myEventHandler(string value); // Define a delegate
    private string theVal;
    public event myEventHandler valueChanged;
    public string val
    {
        set {
            this.theVal = value;
            this.valueChanged(theVal); // When the value changes: fire the event
        }
    }
    
    void Start()
    {
        // Use a lambda expression to define an event handler. Note this is a statement lambda due to the use of {}
        valueChanged += (x) => {
            Debug.Log("The value changed to " + x);
        };
    }
}

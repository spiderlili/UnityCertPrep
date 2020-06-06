using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//each cube will share this script and register the TurnRed() method to onClick event
public class CubeEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //subscribe to onClick event, register a method that matches the delegate signature (void method)
        EventMain.onClick += TurnRed;
    }

    public void TurnRed()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    //when subscribing: always need to unsubscribe when destroying the object to avoid creating errors
    private void OnDisable()
    {
        EventMain.onClick -= TurnRed;
    }
}

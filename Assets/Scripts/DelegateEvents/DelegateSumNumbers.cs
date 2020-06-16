using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelegateSumNumbers : MonoBehaviour
{
    //create a delegate of type void (action) that calculates the sum of 2 numbers
    public Action<int, int> Sum;

    private void Start()
    {
        //use a lambda to avoid having a dedicated method:
        Sum = (a, b) => { var total = a + b; Debug.Log("Total: " + total); };
        Sum(5, 1);
       // Sum = CalculateSum;
       // Sum(5, 5);
    }

    /* dedicated method
    void CalculateSum(int a, int b)
    {
        var total = a + b;
    }
    */
}

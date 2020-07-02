using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelegateReturnSumInt : MonoBehaviour
{
    public Func<int, int, int> onCalculateSum; //input, input, output

    private void Start()
    {
        onCalculateSum = (a, b) => a + b;
        var total = onCalculateSum(5, 5);
        Debug.Log(total);

        /* more game logic
        onCalculateSum = (a, b) =>
        {
            var total = a + b;
            Debug.Log("sum: " + total);
            return total; //must use return keyword
        }; */

    }

    //traditional implementation
    /*
    int CalculateSum(int a, int b)
    {
        return a + b;
    }*/
}

using System;
using System.Collections;
using UnityEngine;

public class DelegateScript : MonoBehaviour
{
    // Declare a delegate type: its instance references a method
    internal delegate void MyDelegate(int num);
    private MyDelegate myDelegate;
    [SerializeField] private int number = 50;

    private void Start()
    {
        // MyDelegate's instance (myDelegate) references the PrintNum method
        myDelegate = PrintNum;
        myDelegate(number);
        
        // MyDelegate's instance (myDelegate) references the DoubleNum method
        myDelegate = DoubleNum;
        myDelegate(number);
    }

    void PrintNum(int num)
    {
        Debug.Log("Print number: " + num);
    }

    void DoubleNum(int num)
    {
        Debug.Log("Double number: " + num * 2);
    }

}

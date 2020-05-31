using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : Pet
{
    protected override void Speak() //access modifier need to match parent (protected)
    {
        Debug.Log("Quack");
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StringLengthFunctionDelegate : MonoBehaviour
{
    //takes in a string and returns its length
    //public delegate int characterStringLength(string characterText);
    public Func<string, int> strLength;

    void Start()
    {
        //using a return type delegate: just like actions but with func
        //strLength = GetCharacters; //subscribe method to it - signature string as a parameter and return type int match
        //lambda example which is identical to the same line above:
        strLength = (name) => name.Length;
        int lengthOfString = strLength("Jon"); //"Jon" will be stored in the name parameter
        Debug.Log("Character Count: " + lengthOfString);

        //traditional delegate method: create delegate instance, assign delegate charStrLength to that method
        //characterStringLength charStrLength = new characterStringLength(GetCharacters);
        //Debug.Log(charStrLength("Jon"));

        //traditional non-delegate method using functions
        //int characterCount = GetCharacters(name);
        //Debug.Log("Character Count: " + characterCount);
    }

    /* not needed if using lambda 
    int GetCharacters(string name) //must match function delegate method signature
    {
        return name.Length;
    } */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DelegateReturnGOLength : MonoBehaviour
{
    //using type return: Func. if using void: Action
    public Func<int> onGetName;
    private void Start()
    {
        onGetName = () => this.gameObject.name.Length;
        int characterCount = onGetName();
        Debug.Log("game object name length: " + characterCount);
    }

    //traditional implementation
    /*int GetName()
    {
        return this.gameObject.name.Length;
    }*/
}

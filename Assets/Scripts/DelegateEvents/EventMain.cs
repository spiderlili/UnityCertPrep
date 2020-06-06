using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventMain : MonoBehaviour
{
    public delegate void ActionClick(); //delegate to store methods for oncomplete event
    public static event ActionClick onClick; //event to allow objects to subscribe to button click

    public void ButtonClick()
    {
        if (onClick != null) //null check on events to prevent error - onClick must have at least 1 listener
        {
            onClick();
        }
    }
}

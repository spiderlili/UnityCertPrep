using System;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public BaseUnit unit;

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 150, 100), "Attack Event Test")) {
            unit.Attacked();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

//display current time as text
public class DisplayTimeCanvasOptimization : MonoBehaviour
{
    private TextMeshProUGUI timeDisplay;
    DateTime currentTime;

    // Start is called before the first frame update
    void Start()
    {
        timeDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        timeDisplay.text = currentTime.ToString("T"); //formats the time as HH:MM:SS:XM - 4:00:00 PM
    }
}

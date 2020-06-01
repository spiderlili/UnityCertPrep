using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ClockDynamicCanvas : MonoBehaviour
{
    private TextMeshProUGUI clock;
    
    // Start is called before the first frame update
    void Start()
    {
        clock = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        clock.text = DateTime.Now.ToString();
    }
}

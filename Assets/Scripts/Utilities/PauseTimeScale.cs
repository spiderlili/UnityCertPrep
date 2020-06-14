using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class PauseTimeScale : MonoBehaviour
{
    [SerializeField] private Image pauseOverlay;
    // Start is called before the first frame update
    void Start()
    {
        pauseOverlay.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 0;
            pauseOverlay.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            pauseOverlay.enabled = false;
        }
    }
}

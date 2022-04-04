using System;
using UnityEngine;
using UnityEngine.UI;

// TODO: Add animation curve to the second hand - overshoot a little with no anticipation

public class ClockTimeAnimation : MonoBehaviour
{
    [SerializeField] private Transform hoursPivot;
    [SerializeField] private Transform minutesPivot;

    [SerializeField] private Transform secondsPivot;
    [SerializeField] private float hoursToDegrees = -30f;
    [SerializeField] private float minutesToDegrees = -6f;
    [SerializeField] private float secondsToDegrees = -6f;
    
    public enum HandRotationMode
    {
        Step = 0,
        Continuous = 1
    }
    public HandRotationMode rotationMode;
    
   private void Awake()
    {
        hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * DateTime.Now.Hour);
        minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * DateTime.Now.Minute);
        secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * DateTime.Now.Second);
        Debug.Log(DateTime.Now);
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan timeContinuous = DateTime.Now.TimeOfDay;
        var timeNow = DateTime.Now;
        switch (rotationMode) {
            case HandRotationMode.Continuous:
                hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * (float)timeContinuous.TotalHours); 
                minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * (float)timeContinuous.TotalMinutes);
                secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)timeContinuous.TotalSeconds);
                break;
            case HandRotationMode.Step:
                hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * timeNow.Hour); // TODO: Change this to timeContinuous
                minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * timeNow.Minute);
                secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * timeNow.Second);
                break;
            default:
                var time = DateTime.Now;
                hoursPivot.localRotation = Quaternion.Euler(0f, 0f, hoursToDegrees * time.Hour);
                minutesPivot.localRotation = Quaternion.Euler(0f, 0f, minutesToDegrees * time.Minute);
                secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * time.Second);
                break;
        }
    }
}

// https://catlikecoding.com/unity/tutorials/basics/game-objects-and-scripts/
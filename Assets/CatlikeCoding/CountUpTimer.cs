using System;
using UnityEngine;
using TMPro;

// TODO: consider updating this in a Coroutine instead of in Update, running every 1/10th of a second or so
// https://forum.unity.com/threads/how-best-to-make-a-timer-utilizing-stringbuilder.530414/

public class CountUpTimer : MonoBehaviour{
    // TODO: Delete
    [SerializeField] private TMP_Text m_ClockText;
    private float m_Timer;
    private int m_Hour = 0;
    private int m_Minute = 0;
    private int m_Second = 0;
    
    // Set timer duration
    [SerializeField] private float timeDurationMinutes = 3f;
    private float timeDurationSeconds;
    private float timer;
     
    // Separate timer objects
    [SerializeField] private TextMeshProUGUI firstHour; // First slot for hours
    [SerializeField] private TextMeshProUGUI secondHour; // Second slot for hours
    [SerializeField] private TextMeshProUGUI firstMinute; // First slot for minutes
    [SerializeField] private TextMeshProUGUI secondMinute; // Second slot for minutes
    [SerializeField] private TextMeshProUGUI firstSecond; // First slot for seconds
    [SerializeField] private TextMeshProUGUI secondSecond; // Second slot for seconds
    [SerializeField] private GameObject timerSeparator; // First slot for seconds

    private float flashTimer;
    [SerializeField] private bool countDown = false;
    [SerializeField] private float flashDuration = 3f;

    // Set current time to the time duration, subtract the time that has elapsed from the timer
    private void ResetTimer()
    {
        if (countDown) {
            timer = timeDurationSeconds;
        } else {
            timer = 0;
        }
        SetTextDisplay(true); // Failsafe
        
        // TODO: Delete
        m_Hour = 0;
        m_Minute = 0;
        m_Second = 0;
    }
    
    private void FlashTimer()
    {
        // Prevent bug of the timer from being dropped to below 0
        if (countDown && timer != 0) {
            timer = 0;
            UpdateTimerDisplay(timer);
        }
        
        // Prevent bug caused by floating point comparison inaccuracy
        if (!countDown && Math.Abs(timer - timeDurationSeconds) > 0.01f) {
            timer = timeDurationSeconds;
            UpdateTimerDisplay(timer);
        }

        // Flash Timer on 0 (if count down) or end of duration (if count up)
        if (flashTimer <= 0) {
            flashTimer = flashDuration;
        }
        else if (flashTimer >= flashDuration / 2) {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(false);
        } else {
            flashTimer -= Time.deltaTime;
            SetTextDisplay(true);
        }
    }

    private void UpdateTimerDisplay(float timeInSeconds)
    {
        float hours = Mathf.FloorToInt(timeInSeconds / 3600);
        float minutes = Mathf.FloorToInt(timeInSeconds / 60); // Round value down so when you're at 0 you get 0
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);
        string currentTime = $"{hours:00}{minutes:00}{seconds:00}";
        firstHour.text = currentTime[0].ToString();
        secondHour.text = currentTime[1].ToString();
        firstMinute.text = currentTime[2].ToString();
        secondMinute.text = currentTime[3].ToString();
        firstSecond.text = currentTime[4].ToString();
        secondSecond.text = currentTime[5].ToString();
    }
    private void UpdateTimerWithFlashOnEnd()
    {
        if (countDown && timer > 0) {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        } else if (!countDown && timer < timeDurationSeconds) {
            timer += Time.deltaTime;
            UpdateTimerDisplay(timer);
        }
        else {
            FlashTimer();
        }
    }

    private void SetTextDisplay(bool textEnabled)
    {
        firstHour.enabled = textEnabled;
        secondHour.enabled = textEnabled;
        firstMinute.enabled = textEnabled;
        secondMinute.enabled = textEnabled;
        firstSecond.enabled = textEnabled;
        secondSecond.enabled = textEnabled;
        timerSeparator.SetActive(textEnabled);
    }
    
    // TODO: Delete
    private void SetTimerTextOneString()
    {
        m_Timer += Time.deltaTime;
        m_Second = (int)m_Timer;     
        if (m_Second > 59.0f)
        {
            m_Second = (int)(m_Timer - (m_Minute * 60));
        }
        m_Minute = (int)(m_Timer / 60);       
        if (m_Minute > 59.0f)
        {
            m_Minute = (int)(m_Minute - (m_Hour * 60));
        }
        m_Hour = m_Minute / 60;
        if (m_Hour >= 24.0f)
        {
            m_Timer = 0;
        }
        m_ClockText.text = $"{m_Hour:d2}:{m_Minute:d2}:{m_Second:d2}"; 
    }
    
    private void Awake()
    {
        timeDurationSeconds = timeDurationMinutes * 60f;
    }
    
    void Start ()
    {
        ResetTimer();
    }

    void Update ()
    {
        UpdateTimerWithFlashOnEnd();
        
        // TODO: Delete
        SetTimerTextOneString();
    }
}
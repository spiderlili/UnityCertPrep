using System;
using UnityEngine;
using TMPro;

// TODO: Add flashing effect once time is up
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
    [SerializeField] private TextMeshProUGUI firstMinute; // First slot for minutes
    [SerializeField] private TextMeshProUGUI secondMinute; // Second slot for minutes
    [SerializeField] private TextMeshProUGUI firstSecond; // First slot for seconds
    [SerializeField] private TextMeshProUGUI secondSecond; // Second slot for seconds
    [SerializeField] private TextMeshProUGUI timerSeparator; // First slot for seconds

    // Set current time to the time duration, subtract the time that has elapsed from the timer
    private void ResetTimer()
    {
        timer = timeDurationSeconds;
        
        // TODO: Delete
        m_Hour = 0;
        m_Minute = 0;
        m_Second = 0;
    }
    
    private void Flash()
    {
        
    }

    private void UpdateTimerDisplay(float timeInSeconds)
    {
        float minutes = Mathf.FloorToInt(timeInSeconds / 60); // Round value down so when you're at 0 you get 0
        float seconds = Mathf.FloorToInt(timeInSeconds % 60);
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();

    }
    private void UpdateTimerWithFlashOnEnd()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
            UpdateTimerDisplay(timer);
        } else {
            Flash();
        }
    }
    
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
        m_ClockText.text = string.Format("{0:d2}:{1:d2}:{2:d2}", m_Hour,m_Minute,m_Second); 
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
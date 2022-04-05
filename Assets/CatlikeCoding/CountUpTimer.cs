using UnityEngine;
using TMPro;

// TODO: Add Hour Separate Object
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
        
        if (!countDown && timer != timeDurationSeconds) {
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
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        // firstHour.text = currentTime[0].ToString();
        // secondHour.text = currentTime[1].ToString();
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();

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
using System;
using UnityEngine;
using TMPro;

public class CountUpTimer : MonoBehaviour{
    public TMP_Text m_ClockText;
    private float m_Timer;
    private int m_Hour = 0;
    private int m_Minute = 0;
    private int m_Second = 0;
    
    void Start ()
    {
        m_Hour = 0;
        m_Minute = 0;
        m_Second = 0;
    }
    
    void Update () {
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DelegateAnonymousMethodTest : MonoBehaviour
{
    [SerializeField] private TMP_Text introNameText;
    [SerializeField] private TMP_Text introAgeText;
    // Use anonymous method on Action<T> Delegate type
    void Start()
    {
        Action<string> tellMeYourName = delegate(string name) {
            string intro = "My name is ";
            introNameText.text = intro + name;
            Debug.Log(intro + name);
        };
        
        Action<int> tellMeYourAge = delegate(int age) {
            string intro = "My age is ";
            string ageString = age.ToString();
            introAgeText.text = intro + ageString;
            Debug.Log(intro + ageString);
        };

        tellMeYourName("Kitty");
        tellMeYourAge(26);
    }
}

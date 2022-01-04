﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Subscribes to LevelUpSubject
public class HealthSubscriber : MonoBehaviour
{
    [SerializeField] float fullHealth = 100.0f;
    [SerializeField] float drainPerSecond = 2.0f;
    float currentHealth = 0;

    private void Awake() {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    public float GetHealth(){
        return currentHealth;
    }

    public void ResetHealth(){
        currentHealth = fullHealth;
    }

    IEnumerator HealthDrain(){
        while(currentHealth > 0){
            currentHealth -= drainPerSecond;
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}
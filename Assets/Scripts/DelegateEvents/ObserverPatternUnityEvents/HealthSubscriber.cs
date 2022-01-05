using System.Collections;
using System;
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

    // Should only communicate with other components in Start()
    private void Start()
    {
        // Add ResetHealth listener which will be called whenever the onLevelUpAction Event happens
        // GetComponent<LevelUpSubject>().onLevelUpAction += ResetHealth;
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

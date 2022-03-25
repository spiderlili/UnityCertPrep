using System.Collections;
using System;
using UnityEngine;

// Subscribes to LevelUpSubject
public class HealthSubscriber : MonoBehaviour
{
    [SerializeField] private float fullHealth = 100.0f;
    [SerializeField] float drainPerSecond = 2.0f;
    [SerializeField] private LevelUpSubject levelUpSubject;
    float currentHealth = 0;
    public event Action ONHealthChange;

    // [SerializeField] private Image healthBarImage; // Refactored in HealthPresenter.cs
    
    private void Awake() {
        ResetHealth();
        StartCoroutine(HealthDrain());
    }

    // Should only communicate with other components in Start()
    private void Start()
    {
        // Use OnEnable instead of Start to Add ResetHealth listener, which will be called whenever the onLevelUpAction Event happens
        // You might Start with a component being disabled - don't want that component to have functions called on it if it's disabled! 
    }

    private void OnEnable()
    {
        // Add ResetHealth listener which will be called whenever the onLevelUpAction Event happens
        levelUpSubject.ONLevelUpAction += ResetHealth;
    }

    private void OnDisable()
    {
        // Remove ResetHealth listener
        levelUpSubject.ONLevelUpAction -= ResetHealth;
    }

    public float GetCurrentHealth(){
        return currentHealth;
    }

    public float GetFullHealth()
    {
        return fullHealth;
    }
    
    private void ResetHealth(){
        currentHealth = fullHealth;
        if (ONHealthChange != null) {
            ONHealthChange();
        }
        // UpdateUI(); // Refactored in HealthPresenter.cs
    }

    IEnumerator HealthDrain(){
        while(currentHealth > 0){
            currentHealth -= drainPerSecond;
            if (ONHealthChange != null) {
                ONHealthChange();
            }
            // UpdateUI(); // Refactored in HealthPresenter.cs
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    /* Refactored in HealthPresenter.cs
    private void UpdateUI()
    {
        healthBarImage.fillAmount = currentHealth / fullHealth;
    }
    */
}

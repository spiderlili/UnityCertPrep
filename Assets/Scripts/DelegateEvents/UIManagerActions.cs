using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerActions : MonoBehaviour
{
    private void OnEnable()
    {
        //subscribe to player onDamage event
        PlayerActions.onDamageReceived += UpdateHealth;
        
    }

    private void OnDisable()
    {
        //unsubscribe to player onDamage event
        PlayerActions.onDamageReceived -= UpdateHealth;
    }

    public void UpdateHealth(int health) //method has to match the delegate signature
    {
        //display updated health
        Debug.Log("health: " + health);
    }
}

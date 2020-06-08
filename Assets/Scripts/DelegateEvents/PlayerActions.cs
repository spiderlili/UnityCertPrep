using System; //allow access to code libraries for using actions
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    //traditional delegate and event system:
    //public delegate void OnDamageReceived(int currentHealth); //other managers can subscribe to damage function 
    //best practice to make events static so you don't have to instantiate an instance of this PlayerActions class - allow it to run along all classes
    //public static event OnDamageReceived onDamage; //people subscribed to onDamage event will look for OnDamageReceived() signature

    //action system: can clean both delegate and event up into 1 line of code
    public static Action<int> onDamageReceived;

    public int Health { get; set; }
    private void Start()
    {
        Health = 10;
    }

    void Damage()
    {
        Health--;
        
        //check if anyone wants to be notified
        if(onDamageReceived != null)
        {
            onDamageReceived(Health); //Raise the onDamage event
        }

        //problem with traditional approach: player has to know about the ui manager
        //UIManager.UpdateHealth();
    }
}

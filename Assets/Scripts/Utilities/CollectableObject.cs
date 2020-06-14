using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    //get info about object that collided with you, collider other stores info about whatever object hit like player
    private void OnTriggerEnter(Collider other) 
    {
        //check who hit me: if only want player to collect me
        if(other.tag == "Player")
        {
            //TODO: add VFX, points / powerup ability
            Destroy(this.gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //Better design with delegates:  
    //player should be independent and not care about who needs to know that they died.
    //Let anyone who's interested in knowing player died have the ability to subscribe to an event. 

    public delegate void OnDeath();
    public static event OnDeath onPlayerDeath;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Death();
        }
    }

    void Death()
    {
        if (onPlayerDeath != null) //check if anyone cares about player death is listening and wants to be notified upon player death
        {
            onPlayerDeath(); //raise the event
        }

        //problematic implementation without delegates: player has to know about the gamemanager and ui manager. 
        //Any concept of code re-usability and modularity has been thrown out - player has to know about ResetPlayer() in gamemanager and ui manager. 
        // GameObject.FindObjectOfType<GameEventsManager>().ResetPlayer();
        // GameObject.FindObjectOfType<UIManager>().UpdateEnemyCount();
    }
}

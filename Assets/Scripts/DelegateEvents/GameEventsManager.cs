using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    private void OnEnable()
    {
        //access player and register to the onPlayerDeath event - assign ResetPlayer() to this event as their signature matches
        PlayerManager.onPlayerDeath += ResetPlayer; //can't directly assign something to an event - can only add methods to it
    }

    private void OnDisable()
    {
        PlayerManager.onPlayerDeath -= ResetPlayer;
    }

    public void ResetPlayer()
    {
        Debug.Log("Reset Player");
    }
}

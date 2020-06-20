using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIEnum : MonoBehaviour
{
    public enum enemyState 
    { 
        patroling,
        attacking,
        chasing,
        death
    }

    public enemyState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = enemyState.patroling;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case enemyState.patroling: //patroling is only going to be for the first 5 seconds of the game
                if(Time.time > 5)
                {
                    currentState = enemyState.chasing;
                }
                break;
            case enemyState.attacking:
                //AI Logic
                break;
            case enemyState.chasing:
                //AI Logic
                break;
            case enemyState.death:
                //AI Logic
                break;
        }
    }
}

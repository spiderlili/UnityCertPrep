using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProperties : MonoBehaviour
{
    public bool IsDead { get; private set; } //other enemy classes check if player is dead, only game manager class can set it
    public int Score { get; private set; } //only the game manager can change the value but UI manager can read it for display

    /*
    //auto property example: can't run any function code within it
    public bool IsGameOver
    {
        get;
        private set; //every object in game can read the value but won't be able to set it
        //protected set; //only this class in the classes that derive this class can change the value of this
    }
    */

    //manual property example:
    private bool isGameOver;
    public bool IsGameOver //property - make it same as public
    {
        get
        {
            return isGameOver;
        }

        set
        {
            if(value == true)
            {
                Debug.Log("Game Over"); //trigger ui
            }
            isGameOver = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = false; //set isGameOver to false through setter
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        IsDead = true;
        IsGameOver = true;
    }
}

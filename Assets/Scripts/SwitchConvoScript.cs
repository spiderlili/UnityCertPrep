using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//switch = more streamlined conditional used to compare a single var to a series of consts
//a common use of switches is to make decisions based on enums
public class SwitchConvoScript : MonoBehaviour {

    //allow a character to give a greeting based on their intelligence
    public int intelligence = 5;

    void Greet() {
        switch (intelligence) {
            case 5:
                print("Hello there! Let's learn about quarternions!");
                break;
            case 4:
                print("Hi! Have a good day!");
                break;
            case 3:
                print("Whadya want?");
                break;
            case 2:
                print("argh howdy");
                break;
            case 1:
                print("glib");
                break;
            default: //else in if-else statement - covers any situations not caught by a preceding condition
                print("Incorrect intelligence level");
                break;
        }
    }

    //switch case enum - make sure both are set to public
    public enum PlayerTeam{ none, blue, red, green, black};
    public PlayerTeam playerTeam = PlayerTeam.none;

    private void Update()
    {
        switch (playerTeam)
        {
            case PlayerTeam.black:
                Debug.Log("Black team found");
                break;
            case PlayerTeam.blue:
                Debug.Log("Blue team found");
                break;
            case PlayerTeam.red:
                Debug.Log("Red team found");
                break;
            case PlayerTeam.green:
                Debug.Log("Green team found");
                break;
            case PlayerTeam.none:
                Debug.Log("No team found");
                break;

            default:
                Debug.Log("No team found - bug");
            break;

        }
    }
}

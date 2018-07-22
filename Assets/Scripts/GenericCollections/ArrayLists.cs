using System.Collections;
using System.Collections.Generic; //required for generic collections - lists and dictionaries

using UnityEngine;

//Using arrays/Lists/Dictionaries to collect variables together into a more manageable form.

public class ArrayLists : MonoBehaviour {

    //array = a block of memory allocated to place multiple objects of the same type inside, like a group or a folder
    //NOTE: an array is not a type but a collection of variables of a certain type

    int[] myIntArray = { 12, 34, 9, 10, 13 }; //quick array init & assign method
    public string[] playerNames = new string[3]; //need to know array length before it can be used
    public GameObject[] players; //allocate values in the inspector with public arrays

    //list = dynamically sized array - don't need to know list length ahead of time
    public List<string> enemyNames = new List<string>();


    void Start () {
        //array assign method(individual)
        playerNames[0] = "John";
        playerNames[1] = "Maria";
        playerNames[2] = "Jane";

        //list assign method(individual)
        enemyNames.Add("boss bee");
        enemyNames.Add("big boss");
        enemyNames.Add("Final boss");

        Debug.Log("player name is: " + playerNames[1] + " boss is: " + enemyNames[2]);

        players = GameObject.FindGameObjectsWithTag("Player");

        //Array work very well with loops - iterate through all objects
        for (int i = 0;  i < players.Length; i++)
        {
            Debug.Log("Player Number " + i + " is named " + players[i].name);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

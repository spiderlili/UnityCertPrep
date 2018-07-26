using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//GetComponent() is expensive and should be called as infrequently as possible => Start() or Awake()

public class UsingOtherComponents : MonoBehaviour {
    public GameObject otherGameObject;

    //references to the other scripts(instance of the class defined in the script)
    private RefScript refScript;
    private RefScriptAlt refScriptAlt;
    private BoxCollider boxCol;

    //script is a component - access script components on other game objects, takes type as a parameter
    //initialise variables

    private void Awake()
    {
        refScript = GetComponent<RefScript>();
        refScriptAlt = otherGameObject.GetComponent<RefScriptAlt>();
        boxCol = otherGameObject.GetComponent<BoxCollider>();
    }

    void Start () {
        boxCol.size = new Vector3(3, 3, 3);
        Debug.Log("The player's score is " + refScript.playerScore);
        Debug.Log("The player has died " + refScriptAlt.numberOfPlayerDeaths);
	}
	
}

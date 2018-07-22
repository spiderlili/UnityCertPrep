using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListExampleClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
        List<BadGuy> badguys = new List<BadGuy>(); //modifier + class name + type to be stored in the list
        badguys.Add(new BadGuy("johnny", 50));
        badguys.Add(new BadGuy("magento", 100));
        badguys.Add(new BadGuy("pip", 500));
        
        //order a list of a given type by any var of that type: relies on the type implementing the IComparable interface
        badguys.Sort();

        //log to see if they've been sorted
        foreach (BadGuy guy in badguys) {
            print(guy.name + " " + guy.power);
        }

        //to start afresh with the list and remove all of the elements
        badguys.Clear();
    }
	
	void Update () {

		
	}
}

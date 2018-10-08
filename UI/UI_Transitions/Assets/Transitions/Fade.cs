/**
 * Fade.cs has a boolean that will start a fade in or out a black panel
 * Author:  Lisa Walkosz-Migliacio  http://evilisa.com  09/18/2018
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour {

    public bool show;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
        {
            if (show) show = false;
            else show = true;
            GetComponent<Animator>().SetBool("show", show);
        }
	}
}

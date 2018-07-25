using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use LookAt to make an object's forward direction point to another transform in the world

public class LookAt : MonoBehaviour {

    public Transform lookAtTarget; 
	
	void Update () {

        //apply to camera and assign an object to track

        transform.LookAt(lookAtTarget); 
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//only methods which takes no parameters and have a return type of void can be called using Invoke()
public class InvokeScript : MonoBehaviour {

    public GameObject target;

	//takes a string containing the method name + amount of time to delay in seconds
	void Start () {
        Invoke("SpawnObject", 2);
	}
    void SpawnObject()
    {
        //instantiate the target object at the position 0,2,0
        Instantiate(target, new Vector3(0, 2, 0), Quaternion.identity);
    }
}

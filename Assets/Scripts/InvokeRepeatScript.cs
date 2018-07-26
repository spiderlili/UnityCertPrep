using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRepeatScript : MonoBehaviour {

    public GameObject target;

	void Start () {
        //method name in string, delay in seconds before it calls the method, delay in seconds between each subsequent call of the method
        InvokeRepeating("SpawnObject", 2, 1);

        //stop all instances of an invoked call with a specific name
        //CancelInvoke("SpawnObject");
	}
	
    //instantiates objects in a random X and Z position
    void SpawnObject()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float z = Random.Range(-2.0f, 2.0f);
        Instantiate(target, new Vector3(x, 2, z), Quaternion.identity);
    }


}

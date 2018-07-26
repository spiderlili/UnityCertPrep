using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceScript : MonoBehaviour {

	void Start () {

        //value type variable
        //Vector3 pos = transform.position;
        //pos = new Vector3(0, 2, 0);

        //reference type variable - Transform class
        //assign the object transform to the reference variable tran, so they point at the same memory address => changing one changes the other
        Transform tran = transform;
        tran.position = new Vector3(0, 2, 0);
        //transform.position = new Vector3(0, 2, 0);
    }

}

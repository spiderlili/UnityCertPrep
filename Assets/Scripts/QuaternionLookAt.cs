using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionLookAt : MonoBehaviour
{

    public Transform target;

    //rotate to face the target transform
    void Update()
    {
        //calculate the relative vector3 between the object and the target
        Vector3 relativePos = target.position - transform.position;

        //LookRotation: takes in a vector3, returns a quarternion rotation aligned with the vector3 passed in
        //make the object's z-axis point towards the target
        //works in a similar way to transform.LookAt but utilising quarternions to set the rotation explicitly
        //can pass in a second vector3 to tell the function which direction is considered up

        transform.rotation = Quaternion.LookRotation(relativePos, new Vector3(0,1,0));
    }
}

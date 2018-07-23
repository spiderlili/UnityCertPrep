using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaternionGravityScript : MonoBehaviour {

    public Transform target;

    // Utilise slerp and forward movement to achieve a gravity orbit effect
    // quaternions are the best way of dealing with rotation - never alter the components independently

    void Start()
    {
        // set euler rotation to (0,0,0) = no rotation
      //  transform.rotation = Quaternion.identity;
    }

    void Update () {

        //calculate the relative vector between the object and the target
        //add an offset to account for the orb's height

        Vector3 relativepos = (target.position + new Vector3(0, 1.5f, 0)) - transform.position;

        //store lookat rotation in a quaternion
        Quaternion rotation = Quaternion.LookRotation(relativepos);

        //store the local rotation of the object in a quaternion
        Quaternion current = transform.localRotation;

        //slowly turn the object to face the target
        //slerp: reads in the current rotation, the end result rotation, the speed it should interpolate(turn)
        //the rotation doesn't happen immediately but over time 

        transform.localRotation = Quaternion.Slerp(current, rotation, Time.deltaTime);

        //after turning the object slightly towards the target: move it forward s little bit
        transform.Translate(0, 0, 3 * Time.deltaTime);


	}
}

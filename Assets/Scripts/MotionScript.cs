using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionScript : MonoBehaviour {

    public float speed = 3f;

    //moves the object side to side based on the horizontal input axis
    void Update () {
        transform.Translate(-Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, 0);
	}
}

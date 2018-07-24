using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//delta = difference between 2 values. gives a value per second rather than per frame.
//deltaTime = time between each update/fixed update function call - good for smoothing out values for incremental calculations.e.g.movement
//time between frames is not constant: if moving obj in each frame by a fixed amount, the overall effect might not be smooth
//the amount of time it takes to complete a frame will vary, despite the distance of movement remaining constant.

public class DeltaTimeScript : MonoBehaviour {

    public float speed = 8f;
    public float countdown = 3.0f;

	void Start () {
		
	}
	
	void Update () {
        // countdown is reduced by the amount of time(in seconds) that it takes to complete each frame
        countdown -= Time.deltaTime;

        if(countdown <= 0.0f)
        {
            GetComponent<Light>().enabled = true;
        }

        //smooth the movement - the speed remains constant even if frame rate varies
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0.0f, 0.0f);
        }
	}
}

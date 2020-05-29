using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformCoroutine : MonoBehaviour
{
    public Transform startPoint, endPoint;
    public float journeyTime = 3;
    public float waitTime = 2;
    private bool forward;
    private float speed;
    private Vector3 destination;
    private float minDistance = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPoint.position;
        destination = endPoint.position;

        if (journeyTime > 0)
            speed = Vector3.Distance(startPoint.position, endPoint.position) / journeyTime;
        else
            speed = 10;
        forward = true;
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            //tracks the platform's distance from the destination
            while(Vector3.Distance(transform.position, destination) > minDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                yield return null;
            }

            //when destination reached: platform pauses for waitTime, changes direction, sets a new destination, restart loop 
            yield return new WaitForSeconds(waitTime);
            forward = !forward;
            destination = forward ? endPoint.position : startPoint.position;
        }
    }
}

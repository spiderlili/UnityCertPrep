using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 velocity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //make sure it's not colliding with other things, put asteroid back in the pool for later reuse rather than destroying it forever
        if (collision.gameObject.tag == "Asteroid")
        {
            //Destroy(collision.gameObject);
            collision.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(velocity);
    }
}
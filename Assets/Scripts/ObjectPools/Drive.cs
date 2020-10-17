using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown("space"))
        {
            //Instantiate(bullet, this.transform.position, Quaternion.identity); //expensive to instantiate bullets all the time, taking up all memory
            GameObject bulletPooled = Pool.singleton.GetPooledItem("bullet"); //recycle the bullet from the object pool
            if (bulletPooled != null)
            {

            }
        }
    }
}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;

    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown("space"))
        {
            //Instantiate(bullet, this.transform.position, Quaternion.identity); //expensive to instantiate bullets all the time, taking up all memory
            GameObject bulletPooled = Pool.singleton.GetPooledItem("Bullet"); //recycle the bullet from the object pool
            if (bulletPooled != null)
            {
                bulletPooled.transform.position = this.transform.position;
                bulletPooled.transform.rotation = Quaternion.identity;
                bulletPooled.SetActive(true); //make it unavailable to reuse from the pool elsewhere
                //Debug.Log("bullet pooled is not null");
            }
        }
    }

    /*
        private void LateUpdate()
        {
            Vector3 viewPosition = transform.position;
            viewPosition.x = Mathf.Clamp(viewPosition.x, screenBounds.x, screenBounds.x * -1);
            transform.position = viewPosition;
        } */
}
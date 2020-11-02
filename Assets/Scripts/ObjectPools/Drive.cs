using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public GameObject bullet;
    public Slider healthBar;
    public float healthBarOffsetY = 80.0f;
    public float asteroidDamage = 10.0f;

    private Vector2 screenBounds;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //make sure it's not colliding with other things, put asteroid back in the pool for later reuse rather than destroying it forever
        if (collision.gameObject.tag == "Asteroid")
        {
            DamageHealthBar();
        }
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
        AlignHealthSliderToShip();
    }

    //update the slider position based on the world position of the ship (the object that this script is attached to), project back to the canvas to get canvas position
    void AlignHealthSliderToShip()
    {
        Vector3 shipScreenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.transform.position = new Vector3(shipScreenPos.x, shipScreenPos.y - healthBarOffsetY, shipScreenPos.z);
    }

    //reduce the value on healthbar when colliding with asteroids
    void DamageHealthBar()
    {
        healthBar.value -= asteroidDamage;
        if (healthBar.value <= 0)
        {
            //if trying to destroy something with code on it which is still running: it might complain & code after this won't run
            Destroy(healthBar.gameObject, 0.1f);
            Destroy(this.gameObject, 0.1f);
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
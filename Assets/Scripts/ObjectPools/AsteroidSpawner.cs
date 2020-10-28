using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public float randomXRange = 10;
    public int maxNumberOfAsteroids = 3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //must wait until the extra asteroids are gone for new asteroids to spawn after exceeding the max limit
        if (Random.Range(0, 100) < maxNumberOfAsteroids)
        {
            //Instantiate(asteroid, this.transform.position + new Vector3(Random.Range(-randomXRange, randomXRange), 0, 0), Quaternion.identity);
            GameObject asteroid = Pool.singleton.GetPooledItem("Asteroid");
            if (asteroid != null)
            {
                //add randomness to asteroid's X position
                asteroid.transform.position = this.transform.position + new Vector3(Random.Range(-randomXRange, randomXRange), 0, 0);
                asteroid.SetActive(true);
            }
        }
    }
}
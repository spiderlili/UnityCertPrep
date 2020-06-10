using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class ArrayMaster : MonoBehaviour
{
    public string[] names = { "Katy", "Steph", "Julian", "Tina", "Joe" };
    public int[] ages = {18, 21, 24, 25, 19 };
    public string[] cars = { "Toyota", "Ford", "Nissan", "Chevrolet", "Honda" };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //int randomID = Random.Range(0, names.Length);
            Debug.Log("random kid's name: " + names[Random.Range(0, names.Length-1)]);
            Debug.Log("random kid's age: " + ages[Random.Range(0, ages.Length - 1)]);
            Debug.Log("random kid's fav car: " + cars[Random.Range(0, cars.Length - 1)]);

            /* print out last kid's name, age, fav car
            Debug.Log("last kid's name: " + names[names.Length - 1]);
            Debug.Log("last kid's age: " + ages[ages.Length - 1]);
            Debug.Log("last kid's fav car: " + cars[cars.Length - 1]);*/
        }
        
    }
}

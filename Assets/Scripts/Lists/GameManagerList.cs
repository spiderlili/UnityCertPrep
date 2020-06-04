using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerList : MonoBehaviour
{
    public List<GameObject> enemiesToSpawnList = new List<GameObject>();
    public GameObject[] objectsToSpawnArray = new GameObject[10]; //arrays must have a fixed size

    // Start is called before the first frame update
    void Start()
    {
        objectsToSpawnArray[0] = new GameObject(); //populate array
        enemiesToSpawnList.Add(new GameObject()); //populate list

        objectsToSpawnArray[2].name = "Jing"; //access element 2 in array
        enemiesToSpawnList[2].name = "Mie"; //access element in list is the same as array
    }
}

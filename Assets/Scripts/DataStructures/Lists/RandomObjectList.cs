using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectList : MonoBehaviour
{
    [SerializeField] private GameObject[] SpawnList = new GameObject[3]; //array of 3 gameobjects to spawn
    [SerializeField] private List<GameObject> gameObjectsCreated = new List<GameObject>(); //store list of created objects
    public int SpawnCount { get; set; } //keep track of number of objects spawned
    private bool triggerLimitChangeColor = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(SpawnCount == 10) 
            {
                triggerLimitChangeColor = true;
                return;
            }
            else
            {
                var objectToSpawn = SpawnList[Random.Range(0, SpawnList.Length)];//select a random object to spawn - temp variable
                Vector3 randomPositionXY = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), 0);
                GameObject go = Instantiate(objectToSpawn, randomPositionXY, Quaternion.identity); //store instantiated object 
                gameObjectsCreated.Add(go); //store instantiated object in list - can't save prefab (objectToSpawn)
                SpawnCount++;
            }
        }
        if(triggerLimitChangeColor == true)
        {
            foreach(var obj in gameObjectsCreated)
            {
                Debug.Log("limit of 10 objects reached!");
                Object.Destroy(obj);
            }
            gameObjectsCreated.Clear(); //clear the list
            triggerLimitChangeColor = false;
            SpawnCount = 0;
        }
    }
}

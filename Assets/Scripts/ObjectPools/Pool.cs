using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//store properties of the object
[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int maxAmount = 6;
}

public class Pool : MonoBehaviour
{
    //everything in the project can access it & any changes will happen in 1 spot
    public static Pool singleton;
    public List<PoolItem> poolItems;
    public List<GameObject> pooledItems;

    private void Awake()
    {
        singleton = this; //equals an instance of this class
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in poolItems)
        {
            for (int i = 0; i < item.maxAmount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                //control whether it's being used or not. when it's in the pool: the obj is going to be initially inactive & ready to be used
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

    //obtain 1 of these pooled items for use in the game by other scripts (Drive.cs)
    public GameObject GetPooledItem(string itemTag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            //if pooled item is inactive & matches the specified tag: it can be used
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == itemTag)
            {
                return pooledItems[i];
            }
        }
        return null; //there is no availble pooled item for use at this time
    }
}
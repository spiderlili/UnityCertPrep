using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//store properties of the object
[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int maxAmount;
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
                //control whether it's being used or not. when it's in the pool: the obj is going to be inactive & ready to be used
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
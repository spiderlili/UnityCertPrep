using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // turn into a singleton for easy accessibility
    // pre-generate a list of bullets using the prefab for recycle & reuse instead of instantiate / destroy
    private static PoolManager _poolManagerInstance;
    public static PoolManager PoolManagerInstance
    {
        get
        {
            if(_poolManagerInstance == null)
            {
                Debug.LogError("Pool Manager does not exist");
            }
            return _poolManagerInstance;
        }
    }

    [SerializeField]
    private GameObject _bulletContainer; //organise the hierarchy with a parent obj
    [SerializeField]
    private GameObject _bulletPrefab;
    [SerializeField]
    private List<GameObject> _bulletPool;

    private void Awake() //init instance while the scene is loading
    {
        _poolManagerInstance = this; //assign instance to this script the obj is attached to
    }

    private void Start()
    {
        _bulletPool = GenerateBulletList(10); //helper method to retrieve form a list
    }

    List<GameObject> GenerateBulletList(int amountOfBullets) //return type method
    {
        for(int i = 0; i<amountOfBullets; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab); //instantiate gameobject & maintains a reference to go when instantiating a clone
            bullet.transform.parent = _bulletContainer.transform;
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }
        return _bulletPool;
    }
}

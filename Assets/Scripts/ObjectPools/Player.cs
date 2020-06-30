using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool 
{ 
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private GameObject _bulletPrefab;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //communicate with object pool, request bullet
                GameObject bullet = PoolManager.PoolManagerInstance.RequestBullet();
                bullet.transform.position = Vector3.zero;

                //instantiate is bad for gc - reuse instead
                //Instantiate(_bulletPrefab);
            }
        }
    }
}

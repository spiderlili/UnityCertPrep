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
                //instantiate is bad for gc - reuse instead
                Instantiate(_bulletPrefab);
            }
        }
    }
}

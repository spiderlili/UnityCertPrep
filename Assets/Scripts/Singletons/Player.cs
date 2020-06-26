using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton { 
    public class Player : MonoBehaviour
    {
    // Start is called before the first frame update
        void Start()
        {
            SpawnManager.SpawnManagerInstance.StartSpawning();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UIManager.UIManagerInstance.UpdateScore(40); 
            }
        }
    }
}

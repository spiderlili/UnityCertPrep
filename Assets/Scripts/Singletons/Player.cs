﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton { 
    public class Player : MonoBehaviour
    {
    // Start is called before the first frame update
        void Start()
        {
            UIManager.UIManagerInstance.UpdateScore(40);
            SpawnManager.SpawnManagerInstance.StartSpawning();
        }
    }
}

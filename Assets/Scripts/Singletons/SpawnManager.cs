using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton { 
    public class SpawnManager : MonoBehaviour
    {
        //create the instance(private)
        private static SpawnManager _spawnManagerInstance;
        public static SpawnManager SpawnManagerInstance //can never be >1 instance = static
        {
            //check if the instance is null, error handle it
            get
            {
                if(_spawnManagerInstance == null)
                {
                    Debug.LogError("Spawn Manager is null");
                }
                return _spawnManagerInstance;
            }
        }

        //assign the instance to this singleton script that the object is attached to
        private void Awake()
        {
            _spawnManagerInstance = this;
        }

        private void Start()
        {
            Debug.Log("NPCName is:" + NPCManager.Instance.NPCName);
            LevelManager.Instance.LoadLevel();
        }

        public void StartSpawning()
        {
            Debug.Log("Spawn starterd"); //have the player call it
        }
    }
}

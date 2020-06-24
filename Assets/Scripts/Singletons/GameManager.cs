using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton { 
public class GameManager : MonoBehaviour
    {
        //define instance of GameManager, can never be >1 instance
        private static GameManager _GMinstance; 

        //Property for other classes to communicate with GameManager
        public static GameManager Instance
        {
            get
            {
                //return it, never allow anyone to set GameManager
                if(_GMinstance == null) //game manager instance does not exist
                {
                    //lasy instantiation: create on the fly
                    Debug.LogError("GameManager is null");
                }
                return _GMinstance;
            }
        }

        //init singleton
        private void Awake() //while the scene is loading
        {
            //assign instance to this script that the obj is attached to
            _GMinstance = this; 
        }

        public void DisplayName()
        {
            Debug.Log("My name is: ");
        }
    }
}
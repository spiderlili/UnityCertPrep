using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton{
    public class UIManager : MonoBehaviour
    {
        //singleton requires a static private var to declare the instance of this class
        private static UIManager _uiManagerInstance;
        //public property to access _uiManagerInstance: never create a set to allow changes
        public static UIManager UIManagerInstance 
        {
            get
            {
                if (_uiManagerInstance == null)
                {
                    //best practice: log error if instance does not exist
                    //Debug.LogError("UI Manager is null");

                    //alternative: lazy instantiation to create it on the fly
                    GameObject go = new GameObject("UI Manager");
                    go.AddComponent<UIManager>();
                }
                return _uiManagerInstance;
            }
        }

        private void Awake()
        {
            _uiManagerInstance = this;
        }

        public void UpdateScore(int score)
        {
            Debug.Log("Score: " + score);
            Debug.Log("Notifying the game manager");
            //Manager classes can talk to each other BUT they can never talk to an object that's not a singleton. 
            GameManager.Instance.DisplayName();
        }
    }
}

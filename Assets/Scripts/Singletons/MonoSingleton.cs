using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton 
{
//create an template class for singletons(abstract) - all singletons can inherit to get properties
//define a generic type <T> of MonoSingleton, specify what <T> is (inherit MonoSingleton<T>)
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
    {
        private static T _instance; //datatype = T (AudioManager/GameManager etc)
        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    //get the method type using typeof, know what class it is
                    Debug.LogError(typeof(T).ToString() + "is null");
                }
                return _instance;
            }
        }

        private void Awake()
        {
            //init instance and allow class<T> to use it as a singleton
            _instance = (T)this; //cast instance as T type: this as T
            Init(); //if not overriden: do not do anything
        }

        //check if instance has been init: provide an implementation to init things
        //can optionally override virutal method: must declare a body cos it's not marked abstract/extern/partial
        public virtual void Init()
        {
            //optional to override
        }
    }
}

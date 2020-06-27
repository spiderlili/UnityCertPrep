using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Singleton { 
//inherit from MonoSingleton of type AudioManager, turn AudioManager into a singleton
    public class NPCManager : MonoSingleton<NPCManager>
    {
        public string NPCName;

        public override void Init()
        {
            base.Init();
            Debug.Log("NPC created");
        }
    }
}

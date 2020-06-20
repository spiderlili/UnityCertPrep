using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enum;

namespace Enum 
{ 
    public class ItemDatabase : MonoBehaviour
    {
        public List<Item> itemDatabase = new List<Item>();

        private void Start()
        {
            itemDatabase[0].DetectTypeAction();
        }
    }
}

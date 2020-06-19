using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UIElements;
using System;

namespace LINQ {
    [System.Serializable]
    public class Item
    {
        public string Name;
        public int ID;
        public int buff;
    }

    public class LinqItemClassFilter : MonoBehaviour
    {
        public List<Item> items;

        //check if itemID3 exists in the list, print out t/f
        //grab all items with buff > 100 
        //calculate average of all buff stats
        private void Start()
        {
            bool isItemID3Here = items.Any(item => item.ID == 3);
            Debug.Log("itemID3 exists: " + isItemID3Here);

            var itemBigBuff = items.Where(item => item.buff > 100);

            foreach(var bigBuff in itemBigBuff)
            {
                Debug.Log("item with buff > 100: " + bigBuff.Name);
            }

            var averageBuff = items.Average(item => item.buff);
            Debug.Log("average buff: " + averageBuff);

            /* traditional average solution
            int buffSum = 0;
            foreach (var item in items)
            {
                buffSum += item.buff;               
            } 

            int averageBuff = buffSum / items.Count;
            Debug.Log("average buff: " + averageBuff);
            */
        }
    }
}

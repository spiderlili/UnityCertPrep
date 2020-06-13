using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dictionary 
{ 
public class ItemDatabase : MonoBehaviour
{
        //list vs dictionary: : list needs to use a foreach loop to filter through items, no quick way to retrive item
        //public List<Dictionary.Item> itemList = new List<Dictionary.Item>(); 

        public Dictionary<int, Dictionary.Item> itemDictionary = new Dictionary<int, Dictionary.Item>();
        public int lookForKeyInDictionary = 0;

        private void Start()
        {
            Dictionary.Item sword = new Dictionary.Item();
            sword.name = "sword";
            sword.id = 0;

            Dictionary.Item bread = new Dictionary.Item();
            bread.name = "bread";
            sword.id = 1;

            Dictionary.Item cape = new Dictionary.Item();
            cape.name = "cape";
            sword.id = 2;

            //itemList.Add(sword);
            itemDictionary.Add(0, sword);
            itemDictionary.Add(1, bread);
            itemDictionary.Add(2, cape);

            //dictionary allows for retrieving item instatnly using a key
            //var firstItem = itemDictionary[0]; 

            foreach(int key in itemDictionary.Keys) //keys might not be sequential: might have random keys based on needs
            {
                Debug.Log("Key: " + key);
            }

            foreach(Dictionary.Item item in itemDictionary.Values) //Values is a KeyValuePair of type Dictionary.Item
            {
                Debug.Log("Item name: " + item.name);
            }

            /*
            //print out each item in dictionary: iterating through key-value pairs
            foreach(KeyValuePair<int, Dictionary.Item> item in itemDictionary)
            {
                Debug.Log("Key: " + item.Key);
                Debug.Log("Value: " + item.Value.name);
            }
            */

            if (itemDictionary.ContainsKey(lookForKeyInDictionary))
            {
                Debug.Log("key exists!");
                var randomLootItem = itemDictionary[lookForKeyInDictionary]; //use case: random loot retrieval based on quest completion
            }
            else
            {
                Debug.Log("key does not exist!");
            }
        }
    }
}

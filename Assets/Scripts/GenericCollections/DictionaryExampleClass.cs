using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//dictionary = similar to lists but have 2 types instead
//each element makes up a key value pair(kvp)
//a list is generally used in place of an array where more flexibility /functionality is required
//a dictionary is used as a collection of value that can be accessed by >=1 key(s)

public class DictionaryExampleClass : MonoBehaviour {

    // Use this for initialization
    void Start () {
        //2 generic types: key(reference to access the 2nd type), value
        Dictionary<string, BadGuy> badguys = new Dictionary<string, BadGuy>();

        //store different search words that can be used to identify specific bad guys
        BadGuy bg1 = new BadGuy("Harvey", 60);
        BadGuy bg2 = new BadGuy("Magento", 100);

        //add to the dictionary - both the key and the value
        badguys.Add("gangsta", bg1);
        badguys.Add("mutant", bg2);

        //accesing an object in the dictionary: insert a key into [] for a corresponding badguy return
        BadGuy magento = badguys["mutant"];
        BadGuy temp = null;

        //will throw an exception error if a key is provided but no such key exists in the dictionary
        //use TryGetValue if not sure if the key exists(key's type, out param of value type)
        //safer but slightly slower than directly referencing the specific key. 
        //use the key within [] for efficiency - only use when the specified key is definitely in the dictionary

        if (badguys.TryGetValue("birds", out temp))
        {
            //success - the key is in the dictionary, returns true

        }
        else {
            //failure - the key is in the dictionary, returns true
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

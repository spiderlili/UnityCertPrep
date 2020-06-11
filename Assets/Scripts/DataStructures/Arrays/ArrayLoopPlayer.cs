using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayLoopPlayer : MonoBehaviour
{
    public int[] itemID;
    public string[] itemName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (var item in itemName) //universal data type
            {
                Debug.Log(item); //iterate through the array and print off everything
                if(item == "Dagger")//Only print out Dagger if it exists
                {
                    Debug.Log("Dagger exsits");
                    Debug.Log(item);
                }                   
            }

            foreach(var itemid in itemID) //universal data type
            {
                Debug.Log(itemid);
            }
            /*
            for(int i = 0; i < itemName.Length; i++)
            {
                if(itemName[i] == "Dagger")
                {
                    Debug.Log("Dagger exsits");
                    Debug.Log("Dagger item ID: " + itemID[i]);
                }
                //Debug.Log(itemName[i]);
            }*/
        }    
    }
}

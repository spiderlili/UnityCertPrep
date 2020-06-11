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
            for(int i = 0; i < itemName.Length; i++)
            {
                if(itemName[i] == "Dagger")
                {
                    Debug.Log("Dagger exsits");
                    Debug.Log("Dagger item ID: " + itemID[i]);
                }
                //Debug.Log(itemName[i]);
            }
        }    
    }
}

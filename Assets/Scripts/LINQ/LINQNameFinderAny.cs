using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//filters through an array of names and check if a specified name is within it. 
//TODO: make it return true regardless of capital case
public class LINQNameFinderAny : MonoBehaviour
{
    public string[] names = { "jon", "katy", "alex", "jessie" };
    public string searchForName = "jon";
    // Start is called before the first frame update
    void Start()
    {
        var nameFound = names.Any(name => name == searchForName); //returns t/f if searchString is within the array
        Debug.Log("name found: " + nameFound);

        //traditional solution using a loop
        /*
        foreach(var name in names)
        {
            if(name == "jon")
            {
                Debug.Log("Found Jon");
            }
        }*/
    }
}

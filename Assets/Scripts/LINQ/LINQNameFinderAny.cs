using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//filters through an array of names and check if a specified name is within it. 
//TODO: make it return true regardless of capital case
public class LINQNameFinderAny : MonoBehaviour
{
    public string[] names = { "jon", "katy", "alex", "jessie", "katy", "james", "james", "matilda" };
    public string searchForName = "jon";
    public bool printAllUniqueNames = false;    
    public bool printAllLongNames = false;
    public int longNameCharactersThreshold = 5;

    // Start is called before the first frame update
    void Start()
    {        
        //search if a name exists
        var nameFound = names.Contains(searchForName);
        //var nameFound = names.Any(name => name == searchForName); //returns t/f if searchString is within the array
        Debug.Log("name found: " + nameFound);

        //traditional solution using a loop: search if a name exists
        /*
        foreach(var name in names)
        {
            if(name == "jon")
            {
                Debug.Log("Found Jon");
            }
        }*/

        //search for distinct names: take the names, return the orginals and put into a new collection
        if(printAllUniqueNames == true)
        {
            var uniqueNames = names.Distinct();
            foreach (var uniqueName in uniqueNames)
            {
                Debug.Log("Unique Name: " + uniqueName);
            }
        }

        //store long names > 5 characters 
        if(printAllLongNames == true)
        {
            var longNameResults = names.Where(name => name.Length > longNameCharactersThreshold);
            foreach (var longName in longNameResults)
            {
                Debug.Log("Long Names: " + longName);
            }
        }
    }
}

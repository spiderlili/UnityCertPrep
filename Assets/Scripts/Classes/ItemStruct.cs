using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemStructExample //struct is a value type - stored in the stack
{
    public string name;
    public int itemID;

    public ItemStructExample(string name, int itemID)
    {
        this.name = name;
        this.itemID = itemID;
    }
}

public class ItemClassVSStruct //class is a reference type - stored in the heap
{
    public string name;
    public int itemID;

    public ItemClassVSStruct(string name, int itemID)
    {
        this.name = name;
        this.itemID = itemID;
    }
}

public class ItemStruct : MonoBehaviour
{  
    int ageTest = 20; //value type holds a data value within its own memory space - directly contain their associated value
    string nameTest = "Moxie"; //reference type contains a pointer to another memory location that holds the data
    
    ItemClassVSStruct gunClass = new ItemClassVSStruct("Gun", 1);
    ItemStructExample breadStruct; //struct do not need to use the new operator: don't need to create an instance of an object 

    private void Start()
    {
        breadStruct.name = "Bread";
        breadStruct.itemID = 2;

        Debug.Log("gun current name: " + gunClass.name);
        ChangeValue(gunClass);
        Debug.Log("gun current name (after ChangeValue method): " + gunClass.name);

        Debug.Log("bread current name: " + breadStruct.name);
        ChangeValue(breadStruct);
        Debug.Log("bread current name (after ChangeValue method): " + breadStruct.name);
    }

    private void ChangeValue(ItemStructExample structItem) //value type
    {
        structItem.name = "Stale Bread"; //doesn't work as value type copies that data and creates its own unique instance of it.
        //breadStruct.name = "Stale Bread"; //works
        //Debug.Log(structItem.name); //works - it created a copy
    }

    private void ChangeValue(ItemClassVSStruct classItem) //reference type allows you to modify data
    {
        classItem.name = "Legendary Gun"; //works - can modify original copies of reference types
    }
}

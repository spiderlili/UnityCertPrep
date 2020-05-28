using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] //makes class visible in the inspector
public class RPGItem 
{
    public string name;
    public int id;
    public string description;

    public RPGItem() //default empty constructor with no parameters
    {

    }

    public RPGItem(string name, int id, string description)
    {
        this.name = name;
        this.id = id;
        this.description = description;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Spell 
{
    public string name;
    public int levelRequired;
    public int itemIdRequired;
    public int expGained;

    public Spell(string name, int levelRequired, int itemIdRequired, int expGained) //assign values to instances
    {
        this.name = name;
        this.levelRequired = levelRequired;
        this.itemIdRequired = itemIdRequired;
        this.expGained = expGained;
    }

    public void Cast()
    {
        //TODO: check for a successful hit, create a fallback which returns hit success + award points
        Debug.Log("Cast Spell: " + this.name);
    }
}

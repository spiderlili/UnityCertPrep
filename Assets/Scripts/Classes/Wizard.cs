using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : MonoBehaviour
{
    public Spell[] spells = new Spell[3]; //certain spells only work at level 1
    // public Spell fireBlast;
    public int level = 1;
    public int exp;

    // Start is called before the first frame update
    void Start()
    {
       spells[0] = new Spell("Fire Blast", 1, 20, 50);
       spells[1] = new Spell("Wind Blast", 1, 10, 35);
       spells[2] = new Spell("Ice Blast", 4, 30, 55);
    }

    // Update is called once per frame
    void Update()
    {
        //iterate through the spell list for available options, compare to current level, only cast spell that matches the level
        //TODO: based on the spell: Create particle effects that resemble and associate to that one
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach(var spell in spells)
            {
                if(spell.levelRequired == level)
                {
                    spell.Cast();
                    exp += spell.expGained;
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    [SerializeField]
    RPGItem sword;
    RPGItem hammer;
    RPGItem bread;

    //populate the database via inspector
    public RPGItem[] items;

    // Start is called before the first frame update
    void Start()
    {
        //doesn't make sense to init items this way if have many items (>10): constructor is easier to manage
        sword = new RPGItem();
        sword.name = "Sword";
        sword.id = 1;
        sword.description = "Legendary Sword";

        //constructor method:
        hammer = new RPGItem("Hammer", 2, "Giant Hammer");

        //create items via another custom function
        bread = CreateItem("Bread", 3, "Tasty");
    }

    //a function that creates items:
    private RPGItem CreateItem(string name, int id, string description)
    {
        //create a generic item
        var item = new RPGItem(name, id, description);
        return item; //must return to retrieve the item created
    }
}

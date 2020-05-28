using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Item
{
    //instance members
    public string name;
    public int itemId;

    //static members: in the life of the program, this data is shared across all instances and remains constant
    public static int itemCount;

    public Item()
    {
        itemCount++;
    }
}

//create a new player every time a player is connected & increment connectionCount through Player() constructor
public class Player
{
    public int id;
    public string name;
    public static int connectionCount;

    public Player()
    {
        connectionCount++;
    }
}

public class InstanceMemberVSstaticMember : MonoBehaviour
{
    public Text itemCountText;
    // Start is called before the first frame update
    void Start()
    {
        //instance members of Item class are created as copies: each one has its own unique variables
        Item sword = new Item(); 
        Item mochi = new Item();
        Item hairclip = new Item();
        sword.name = "Sword"; //can access instance members but can't access static members

        //only way to access static member
        Debug.Log("Item Count: " + Item.itemCount);
        itemCountText.text = ("Item Count: " + Item.itemCount);

        Player p1 = new Player(); //unique player instances 
        Player p2 = new Player();
        Debug.Log("Player: " + Player.connectionCount);
    }
}

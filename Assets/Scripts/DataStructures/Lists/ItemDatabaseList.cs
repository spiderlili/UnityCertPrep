using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class ItemDatabaseList : MonoBehaviour //singleton manager
{
    public List<ItemForList> itemDatabse = new List<ItemForList>(); //best practice to init as new List<T>()

    //handle the process of giving away items to player
    //Search by id, parse in player that's making the request(multiplayer/co-op)
    public void AddItem(int itemID, PlayerForList playerRequest) 
    {
        //check if item matches something in the database
        foreach(var item in itemDatabse)
        {
            if (item.id == itemID) //add to inventory
            {
                Debug.Log("item id matches");
                //check for available inventory slots, find first empty slot in array
                for (int i = 0; i < playerRequest.inventory.Length; i++)
                {
                    if (playerRequest.inventory[i].name == null)
                    {
                        playerRequest.inventory[i] = item;
                        break; //stop executing after finding the 1st index
                    }
                }
                return;
            }
        }
        Debug.Log("item does not exist");
    }

    //check if item exists before removing it
    public void RemoveItem(int itemID, PlayerForList player)
    {
        foreach (var item in itemDatabse)
        {
            if (item.id == itemID)
            {
                //check for available inventory slots, find first slot in array with the item id
                for (int i = 0; i < player.inventory.Length; i++)
                {
                    if (player.inventory[i].id == itemID && player.inventory[i].name != null)
                    {
                        player.inventory[i] = null; //can't remove element from array
                        break; //stop executing after finding the 1st index
                    }
                }
                return;
            }
        }
        Debug.Log("item does not exist");
    }
}


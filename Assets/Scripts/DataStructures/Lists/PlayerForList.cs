using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForList : MonoBehaviour //player is able to store 10 items
{
    //items is an array because it's not going to grow / shrink - only 10 items slot for inventory
    public ItemForList[] inventory = new ItemForList[10]; //best practice to always init with a value
    private ItemDatabaseList itemDatabaseList;
    public int itemIDtoRequest = 0;

    private void Start()
    {
        itemDatabaseList = GameObject.Find("ItemDatabaseList").GetComponent<ItemDatabaseList>();
    }

    //request items when hit space
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //request to add item by id
            itemDatabaseList.AddItem(itemIDtoRequest, this);
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            //Remove item by id
            itemDatabaseList.RemoveItem(itemIDtoRequest, this);
        }
    }
}

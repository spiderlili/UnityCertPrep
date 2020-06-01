using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

//responsible for showing and hiding items in the inventory
public class InventoryDisplay : MonoBehaviour
{
    public void ShowOnly(int itemType)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            InventoryItemButton thisItem = transform.GetChild(i).GetComponent<InventoryItemButton>();
            thisItem.gameObject.SetActive(thisItem.index == itemType); //show only this item type
        }
    }

    public void ShowAll()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            InventoryItemButton thisItem = transform.GetChild(i).GetComponent<InventoryItemButton>();
            thisItem.gameObject.SetActive(true);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enum 
{ 
[System.Serializable]
public class Item
    {
        public string itemName;
        public int ID;
        public Sprite icon;

        public enum ItemType
        {
            None,
            Weapon,
            Consumable
        }

        public ItemType itemType;

        public void DetectTypeAction()
        {
            switch (itemType)
            {
                case ItemType.Weapon:
                    Debug.Log("it's a weapon");
                    break;
                case ItemType.Consumable:
                    Debug.Log("it's a consumable");
                    break;
                case ItemType.None:
                    Debug.Log("it's none");
                    break;
            }
        }
    }
}

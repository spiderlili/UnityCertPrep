using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemButton : MonoBehaviour
{
    private Text buttonText;
    private string[] itemTypes = { "Armor", "Weapon", "Spell" };
    public int index;

    // Start is called before the first frame update
    void Awake()
    {
        index = Random.Range(0, 3);
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = itemTypes[index];
    }
}

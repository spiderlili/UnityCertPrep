using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILayoutGroupDisableWhenReachLimit : MonoBehaviour
{
    [SerializeField] private int numComponents = 1;
    [SerializeField] private int maxComponents = 6;
    [SerializeField] private Transform layoutParent;

    private void Start()
    {
        if(layoutParent == null)
        {
            layoutParent = GameObject.Find("Layout Group").transform;
        }
    }

    public void AddNewSlot()
    {
        if (numComponents <= maxComponents)
        {
            numComponents++;
            GameObject button = new GameObject();
            button.transform.parent = layoutParent;
            button.transform.localScale = new Vector3(1, 1, 1);
            button.transform.localPosition = new Vector3(960, -25, 0);
            button.AddComponent<RectTransform>();
            button.AddComponent<Button>();
            button.AddComponent<Image>();
            button.AddComponent<CanvasRenderer>();
            button.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 50);
        }
        else
        {
            DisableLayoutGroup();
        }
    }

    public void DisableLayoutGroup()
    {
        layoutParent.GetComponent<LayoutGroup>().enabled = false;
    }
}

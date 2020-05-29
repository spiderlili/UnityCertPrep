using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideshowCoroutine : MonoBehaviour
{
    public RawImage display;
    public Texture[] slides;
    public float displayTime = 5;
    private RectTransform displayRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        displayRectTransform = display.GetComponent<RectTransform>();
        StartCoroutine(Display());
    }

    IEnumerator Display()
    {
        while (true) //loop code indefinitely
        {
            foreach(Texture slide in slides)
            {
                displayRectTransform.sizeDelta = new Vector2(slide.width, slide.height);
                display.texture = slide;
                yield return new WaitForSeconds(displayTime);
            }
        }
    }
}

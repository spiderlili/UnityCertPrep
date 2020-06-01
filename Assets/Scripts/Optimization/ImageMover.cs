using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

//move the image around in a circular spiral motion, centred around baseRectTransform
public class ImageMover : MonoBehaviour
{
    public RectTransform baseRectTransform; //anchor image to the centre of the baseRectTransform (canvas)
    private float minDistance, maxDistance, distance;
    private float spinSpeed = 4;
    private RectTransform rectTransform;
    private Vector3 basePosition;
    private Vector3 positionOffset = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        basePosition = baseRectTransform.position;
        minDistance = Screen.height * 0.1f;
        maxDistance = Screen.height * 0.3f;
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Mathf.Lerp(minDistance, maxDistance, Mathf.Cos(Time.time) * 0.5f + 0.5f);
        positionOffset.x = distance * Mathf.Cos(Time.time * spinSpeed);
        positionOffset.y = distance * Mathf.Sin(Time.time * spinSpeed);
        rectTransform.position = basePosition + positionOffset;
    }
}

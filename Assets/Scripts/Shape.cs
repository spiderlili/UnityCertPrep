using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    public string Name;
    protected GameSceneController gameSceneController;

    //if move the player/projectile/enemy to the screenbounds: half of the object will be off camera - account for this behaviour
    protected float halfWidth;
    protected float halfHeight;
    private SpriteRenderer spriteRenderer;

    protected virtual void Start()
    {
        //FindObjectOfType: generic function that finds and returns an instance of specified class
        gameSceneController = FindObjectOfType<GameSceneController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        halfWidth = spriteRenderer.bounds.extents.x;
        halfHeight = spriteRenderer.bounds.extents.y;
    }

    public void SetColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }

    //overloading method
    public void SetColor(float red, float green, float blue)
    {
        Color newColor = new Color(red, green, blue);
        spriteRenderer.color = newColor;
    }
}

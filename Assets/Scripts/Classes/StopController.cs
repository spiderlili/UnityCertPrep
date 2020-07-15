using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(SpriteRenderer))]
public class StopController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        //By using the getComponent method: assuming any game object that this script is attached to will have a SpriteRenderer component.
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }
}

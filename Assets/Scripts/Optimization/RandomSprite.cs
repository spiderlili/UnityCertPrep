using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a single / small set of sprites / particles can look like more by varying the color of the renderer
public class RandomSprite : MonoBehaviour
{
    public Sprite[] sprites;
    SpriteRenderer sprite;
    public Color colorOne, colorTwo;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = sprites[Random.Range(0, sprites.Length)];
        sprite.color = Color.Lerp(colorOne, colorTwo, Random.value);
    }
}

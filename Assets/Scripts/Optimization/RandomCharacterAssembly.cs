using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Non-player characters (NPCs), weapons, or anything that can be assembled piece-by-piece, 
can be built of randomly selected different parts. 
Individual parts are quicker to make than full assets and can be assembled in combinations the designer may never have thought of. 
This Random Assembly component would be attached to a player or NPC. 
Manually assign your SpriteRenderer components by dragging them into their respective slots in the Inspector.
drag as many Sprites as you’d like for each option. 
This could be extended to a character creation utility, where pieces are specically chosen by the user, 
and/or combined with a RandomColor script to add color as well as configuration.
 */

public class RandomCharacterAssembly : MonoBehaviour
{
    public Sprite[] headSprites;
    public Sprite[] bodySprites;
    public Sprite[] swordSprites;
    public Sprite[] shieldSprites;

    public SpriteRenderer headSpriteRenderer;
    public SpriteRenderer bodySpriteRenderer;
    public SpriteRenderer swordSpriteRenderer;
    public SpriteRenderer shieldSpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        headSpriteRenderer.sprite = headSprites[Random.Range(0, headSprites.Length)];
        bodySpriteRenderer.sprite = bodySprites[Random.Range(0, bodySprites.Length)];
        swordSpriteRenderer.sprite = swordSprites[Random.Range(0, swordSprites.Length)];
        shieldSpriteRenderer.sprite = shieldSprites[Random.Range(0, shieldSprites.Length)];
    }
}

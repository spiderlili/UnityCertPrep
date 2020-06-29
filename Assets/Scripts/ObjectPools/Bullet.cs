using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        //Destroy is bad for GC - recycle instead
        //Destroy(this.gameObject, 1f); //destroy itself after 1 second
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable() //everytime object is active
    {
        Invoke("Hide", 1); //call hide after 1 second
    }

    private void Start()
    {
        //Destroy is bad for GC - recycle instead
        //Destroy(this.gameObject, 1f); //destroy itself after 1 second
    }

    void Hide()
    {
        //recycle gameobject
        this.gameObject.SetActive(false);
    }
}

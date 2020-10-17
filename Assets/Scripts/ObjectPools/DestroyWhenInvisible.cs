using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenInvisible : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        //Destroy(this.gameObject);
        this.gameObject.SetActive(false); //make it go back to the pool automatically
    }
}
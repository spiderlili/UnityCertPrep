using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventMain.onClick += Fall;
    }

    public void Fall()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}

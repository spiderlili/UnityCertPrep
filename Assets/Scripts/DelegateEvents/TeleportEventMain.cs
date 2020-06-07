using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//object should subscribe to the event and be invoked
public class TeleportEventMain : MonoBehaviour
{
    public delegate void ActionTeleport(Vector3 pos); //delegate signature is a method to accept a position
    public static event ActionTeleport onTeleport; //static so it runs along the entire class - don't need new instances

    public void TeleportSpacePress()
    {
        if(onTeleport != null)
        {
            Vector3 pos = new Vector3(5, 2, 0);
            onTeleport(pos);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TeleportSpacePress(); //invoke onTeleport method
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTeleport : MonoBehaviour
{
    private void Start()
    {
        TeleportEventMain.onTeleport += Spawn; //register for event
    }

    private void OnDisable()
    {
        TeleportEventMain.onTeleport -= Spawn; //de-register if object is destroyed
    }

    //invoke the method from the event, pass in parameter assigned
    public void Spawn(Vector3 pos) //when the player dies, they have their respawn position - must match onTeleport delegate method signature
    {
        transform.position = pos;
    }
}

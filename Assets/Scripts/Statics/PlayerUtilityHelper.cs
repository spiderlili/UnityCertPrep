using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilityHelper : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UtilityHelper.CreateObject(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            UtilityHelper.SetPositionToZero(this.gameObject);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            UtilityHelper.SetRandomColor(this.gameObject, Color.red, true);
        }
    }
}

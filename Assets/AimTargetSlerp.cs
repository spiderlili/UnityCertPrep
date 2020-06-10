using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTargetSlerp : MonoBehaviour
{
    [SerializeField] private Transform targetToAim;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(targetToAim != null)
        {
            Vector3 directionToFace = targetToAim.position - this.transform.position;
            Debug.DrawRay(this.transform.position, directionToFace, Color.green);
            Quaternion targetRotation = Quaternion.LookRotation(directionToFace);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5.0f); //5 meters per second for rotation
        }
    }
}

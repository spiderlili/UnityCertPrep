using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPolymorphism : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition); //cast a ray from mouse position
            RaycastHit hitInfo; //store data of whatever the ray hit

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                //check if something hit, if so apply damage
                if(hitInfo.collider.name == "Player")
                {
                    hitInfo.collider.GetComponent<PlayerPolymorphism>().Damage(100);
                }
                else if (hitInfo.collider.name == "Enemy")
                {
                    hitInfo.collider.GetComponent<EnemyPolymorphism>().Damage(200);
                }
            }
        }
    }
}

using Microsoft.Win32;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleCrate : MonoBehaviour
{
    [SerializeField] private GameObject fracturedCratePrefab;
    [SerializeField] private GameObject explosionVFXPrefab;
    [SerializeField] private float explosionForce = 500f;
    [SerializeField] private float explosionRadius = 1.0f; //affect other objects: sphere radius within which the explosion has its effect

    // Start is called before the first frame update
    void Start()
    {
        if(explosionForce == 0)
        {
            explosionForce = 500f;
        }
        if (explosionRadius == 0)
        {
            explosionRadius = 1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //instantiate the fractured object for smokes and mirror effect, then remove this solid object of hollow crate
            Instantiate(explosionVFXPrefab, transform.position, Quaternion.identity); //trigger VFX

            //Instantiate at the exact place of this object, store instantiated object as a reference into fracturedCrate variable
            GameObject fracturedCrate = Instantiate(fracturedCratePrefab, transform.position, Quaternion.identity);

            //create a rigidbody array, get all rigidbodies and act on them
            Rigidbody[] allRigidBodies = fracturedCrate.GetComponentsInChildren<Rigidbody>();

            //check if gathered any rigidbodies, if yes: iterate through them, add forces
            if (allRigidBodies.Length > 0) //checking array length is better than checking if(allRigidBodies != null)
            {
                foreach(var rb in allRigidBodies)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
                }
            }

            Destroy(this.gameObject);
        }
    }
}

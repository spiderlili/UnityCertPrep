using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPolymorphism : MonoBehaviour, IDamageable
{
    public int Health { get; set; }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

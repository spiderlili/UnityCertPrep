using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPolymorphism : MonoBehaviour, IDamageable
{
    public int Health { get; set; }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

}

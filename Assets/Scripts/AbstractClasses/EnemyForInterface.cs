using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//inherit multiple interfaces - polymorphism
public class EnemyForInterface : MonoBehaviour, IDamageable, IShootable
{
    public int Health { get; set; }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForInterface : MonoBehaviour, IDamageable
{
    public int Health { get; set; }

    public void Damage(int damageAmount)
    {
        Health -= damageAmount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageableGeneric<T> 
{
    int Health { get; set; } //interfaces can only use properties and methods

    void Damage(T damageAmount); //
}

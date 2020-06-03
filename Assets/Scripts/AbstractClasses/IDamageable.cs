using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    int Health { get; set; } //interfaces can only use properties and methods

    void Damage(int damageAmount); //interface methods does not allow implementation details
}

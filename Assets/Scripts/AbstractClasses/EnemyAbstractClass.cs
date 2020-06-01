using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstractClass : MonoBehaviour
{
    public int speed;
    public int health;
    public int gems;

    //dying is the same across every enemy but enemies have different attacks
    public abstract void Attack();

    public virtual void Die() 
    {
        Destroy(this.gameObject);
    }
}

public class MossGiant : EnemyAbstractClass
{
    public override void Attack() //child class of abstract class must implement its abstract method
    {
        //attack is the same across all enemies
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        //die is different in certain enemies: custom particles when the boss enemy dies
        base.Die();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyEscapedHandler(EnemyController enemy);

public class EnemyController : MonoBehaviour
{
    public event EnemyEscapedHandler EnemyEscaped;
    public event Action<int> EnemyKilled; //no need to create a delegate

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //MoveEnemy(gameSceneController.OutputText);
        MoveEnemy(InternalOutputText);
    }

    //can call any method that has access to the delegate regardless of whether that method resides in this code
    private void InternalOutputText(string output) //method signature & argument matches the delegate
    {
        Debug.LogFormat("{0} output by EnemyController", output); //use a parameter list
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    //use delegate to parameterise the method: can take any method matching the signatures & argument, call it through delegate
    private void MoveEnemy(TextOutputHandler textOutputHandler)
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);
        float bottom = transform.position.y;
        //if(bottom <= -gameSceneController.screenBounds.y)
        //{
            textOutputHandler("Enemy at bottom"); //callback delegate
            //GameSceneController.KillObject(this);
        //}
    }

    //fire an EnemyKilled event every time it's hit by a projectile
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(EnemyKilled != null)
        {
            EnemyKilled(10);
            Destroy(collision.gameObject); //destroy instance of the projectile hitting the enemy
            Destroy(gameObject); //destroy instance of enemy
        }
    }

    private void MoveEnemyForRaiseEvent()
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);
        float bottom = transform.position.y;
        //if(bottom <= -gameSceneController.screenBounds.y)
        //{
        //any class with access to the enemy controller can subscribe to this event
        //can be simplified to: EnemyEscaped?.Invoke(this); less readable
        if (EnemyEscaped != null)
        {
            EnemyEscaped(this); //this represents the current instance of this EnemyController class, conform to delegate signature
        }
        //GameSceneController.KillObject(this);
        //}
    }
}

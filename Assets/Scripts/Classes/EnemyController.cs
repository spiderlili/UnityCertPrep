using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
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
        Debug.LogFormat("{0} output by EnemyController", output);
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
}

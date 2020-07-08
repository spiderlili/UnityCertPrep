using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextOutputHandler(string text); //can represent any method with matching signature

public class GameSceneController : MonoBehaviour
{
    public float playerSpeed;
    public Vector3 screenBounds;
    public EnemyController enemyPrefab;
    public int spawnCycleSeconds = 2;

    void Start()
    {
        playerSpeed = 10;
        screenBounds = GetScreenBounds();
        StartCoroutine(SpawnEnemies());
    }

    //spawn enemies at the top of the screen every few seconds
    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnCycleSeconds);
        while (true)
        {
            //creates a random horiztonal position within the bounds at the top of the screen, stores in spawnPosition 
            float horizontalPosition = Random.Range(-screenBounds.x, screenBounds.x);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBounds.y);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            yield return wait;
        }
    }

    //returns the border of the screen in world space
    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main;
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        return mainCamera.ScreenToWorldPoint(screenVector); 
    }

    public void OutputText(string output) //matches the signature of the TextOutputHandler delegate
    {
        Debug.LogFormat("{0} output by GameSceneController", output);
    }
}

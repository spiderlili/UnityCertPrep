﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextOutputHandler(string text); //can represent any method with matching signature

public class GameSceneController : MonoBehaviour
{
    [Header("Player Settings")]
    [Range(5,20)]
    public float playerSpeed = 10f; //public as used by other game objects

    [Header("Screen Settings")]
    [Space]
    public Vector3 screenBounds; //public as used by other game objects

    [Header("Prefab")]
    [Space]
    [SerializeField]
    private EnemyController enemyPrefab; //based on the principle of encapsulation – this really ought to be private!  
    public int spawnCycleSeconds = 2;

    private HUDController hudController;
    private int totalPoints;

    void Start()
    {
        screenBounds = GetScreenBounds();
        StartCoroutine(SpawnEnemies());
        hudController = FindObjectOfType<HUDController>();
    }

    //spawn enemies at the top of the screen every few seconds
    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnCycleSeconds);
        while (true)
        {
            //creates a random horiztonal position within the bounds at the top of the screen, stores in spawnPosition 
            float horizontalPosition = UnityEngine.Random.Range(-screenBounds.x, screenBounds.x);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBounds.y);

            //create an instance of enemy to work with, subscribe to its enemyEscaped event
            EnemyController enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            enemy.EnemyEscaped += EnemyAtBottom;
            enemy.EnemyKilled += EnemyKilled;
            yield return wait;
        }
    }

    private void EnemyKilled(int pointValue)
    {
        totalPoints += pointValue;
        hudController.scoreText.text = totalPoints.ToString(); 
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

    private void EnemyAtBottom(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        Debug.Log("Enemy Escaped");
    }

    public void KillObject(IKillable killable)
    {
        Debug.LogWarningFormat("{0} killed by Game Scene Controller", killable.GetName());
        killable.Kill(); //will take any class/struct that implements IKillable
    }
}

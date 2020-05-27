using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private UIManager _uiManager;
    private void OnEnable()
    {
        SpawnManager.enemyCount++;
        _uiManager = GameObject.Find("UI Manager").GetComponent<UIManager>();
        _uiManager.UpdateEnemyCount();
        Die();
    }

    private void OnDisable()
    {
        SpawnManager.enemyCount--;
        _uiManager.UpdateEnemyCount();
    }

    void Die()
    {
        Destroy(this.gameObject, Random.Range(2, 6));
    }
}

using Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoSingleton<LevelManager>
{
    public override void Init()
    {
        Debug.Log("Level created");
    }

    public void LoadLevel()
    {
        Debug.Log("Level loaded");
    }
}

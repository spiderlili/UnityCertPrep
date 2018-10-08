/**
 * NextScene.cs asynchnolously load another scene with a small wait timer
 * Author:  Lisa Walkosz-Migliacio  http://evilisa.com  09/18/2018
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NextScene : MonoBehaviour {

    public string sceneName; // name of the scene you will load to

    AsyncOperation async; // information about the scene you are loading

    bool waitForLoad; // variable that keeps track in your are showing the loading screen
    float timer; // keep track of how much time you are waiting to load
    float timerWait; // minimum time to wait for the load

    // Use this for initialization
    void Start () {
        waitForLoad = false;
        timerWait = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            waitForLoad = true;
            async = SceneManager.LoadSceneAsync(sceneName);
            async.allowSceneActivation = false;
        }
        
        if (waitForLoad)
        {
            timer += Time.deltaTime;
            if (timer >= timerWait/* || async.progress >= 0.9f*/)
            {
                waitForLoad = false;
                async.allowSceneActivation = true;
            }
        }
    }
}

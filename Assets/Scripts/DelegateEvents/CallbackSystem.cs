using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//call back when things have finished running and control game logic on what should happen next
public class CallbackSystem : MonoBehaviour
{
    public float waitForSeconds = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        //pass in annonymous method(), call the coroutine to run onComplete - it's no longer null
        StartCoroutine(CallbackCoroutine(()=> 
        {
            Debug.Log("Waited for: " + waitForSeconds + " Seconds");
            Debug.Log("CallbackCoroutine finished");
        }));
    }

    public IEnumerator CallbackCoroutine(Action onComplete = null) //optional as a method: looking for an onComplete delegate
    {
        yield return new WaitForSeconds(waitForSeconds);

        //best practice with delegates: make sure someone is listening - no null info
        if (onComplete != null)
        {
            onComplete(); //trigger delegate
        }

        //better alternative: pass in an annonymous method using an action
        //Debug.Log("CallbackCoroutine finished"); 
    }
}

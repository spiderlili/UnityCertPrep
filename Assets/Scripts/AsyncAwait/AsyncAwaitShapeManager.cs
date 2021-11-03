using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Random = UnityEngine.Random;

public class AsyncAwaitShapeManager : MonoBehaviour
{
    [SerializeField] private AsyncAwaitShape[] shapes;
    [SerializeField] private float extraTimeForNextShape = 1.0f;
    [SerializeField] private bool isSynchronous;
    [SerializeField] private GameObject finishedText;
    
    // Async workflow Example: Return data from Task by wrapping it up in async Task<T>
    async Task<int> GetRandomNumber()
    {
        var randomNumber = Random.Range(100, 300); // Unity & coroutines uses floats as seconds, but with C# & Tasks they use miliseconds! 
        await Task.Delay(randomNumber);
        
        // Can cancel the task: if doing a button click which runs a long running task on UI - cancel it if it's taking too long
        return randomNumber;
    }
    
    // Async Workflow complex example: the 1st shape runs sequentially, After that completes run asynchronously 
    public async void BeginTestRotateComplexExample()
    {
        finishedText.SetActive(false);
        
        // The 1st task runs sequentially
        await shapes[0].RotateForSeconds(extraTimeForNextShape + extraTimeForNextShape * 0);

        // After the 1st task has been completed: run tasks after that synchronously
        var tasks = new List<Task>();
        for(var i = 0; i < shapes.Length; i++) {
            tasks.Add(shapes[i].RotateForSeconds(extraTimeForNextShape + extraTimeForNextShape * i));
        }

        await Task.WhenAll(tasks); // Wait for all tasks to complete before continuing
        
        finishedText.SetActive(true);

        var randomNumber = await GetRandomNumber(); // Important to await async function. If do not await: it will return the Task object rather than Task result!
        // var randomNumber = GetRandomNumber().GetAwaiter().GetResult();
        print ("Random number after task completion" + randomNumber);
    }
    
    // Async Workflow Example: run synchronously all at once But still make sure they are all done before continuing to the next logic. 
    public async void BeginTestRotateSynchronous()
    {
        finishedText.SetActive(false);
        
        var tasks = new Task[shapes.Length];
        for(var i = 0; i < shapes.Length; i++) {
            // Complete 1st iteration before going to the second iteration
            tasks[i] = shapes[i].RotateForSeconds(extraTimeForNextShape + extraTimeForNextShape * i);
        }

        await Task.WhenAll(tasks); // Wait for all tasks to complete before continuing
        
        finishedText.SetActive(true);
    }

    // Async Workflow Example: returns Task, wait for task completion before proceeding to the next task
    public async void BeginTestRotateAsync()
    {
        for(var i = 0; i < shapes.Length; i++) {
            // Complete 1st iteration before going to the second iteration
            await shapes[i].RotateForSeconds(extraTimeForNextShape + extraTimeForNextShape * i);
        }
    }
    
    public void BeginTestRotate()
    {
        // Each loop will add a bit more time => each shape rotation will last a bit extra time, keep speeding up stacking as button is pressed
        for (var i = 0; i < shapes.Length; i++) {
            // Async Workflow Example (simple): returns void
            shapes[i].RotateForSeconds(extraTimeForNextShape + extraTimeForNextShape * i);
            
            // Coroutine Example
            // StartCoroutine(shapes[i].RotateForSeconds(1 + 1 * i));
        }
    }
}

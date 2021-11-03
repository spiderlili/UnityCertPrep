using System.Collections;
using System.Threading.Tasks; // Required for await Task.Yield();
using UnityEngine;

public class AsyncAwaitShape : MonoBehaviour
{
    // Async workflow Example (advanced): returns Task so we can monitor if it's done, how long it's elapsed, if we want to cancel it (if it's a long-running task)
    public async Task RotateForSeconds(float duration)
    {
        var end = Time.time + duration; // Time.time is the time in seconds at the beginning of this frame since the start of the application (Read Only).
        while (Time.time < end) {
            transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
            await Task.Yield(); // equiavalent to yield return null 
        }
    }
    
    // Async workflow Example (simple): returns void
    /*
    public async void RotateForSeconds(float duration)
    {
        var end = Time.time + duration; // Time.time is the time in seconds at the beginning of this frame since the start of the application (Read Only).
        while (Time.time < end) {
            transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
            await Task.Yield(); // equiavalent to yield return null 
        }
    }*/
    
    // Coroutine Example
    /*
    public IEnumerator RotateForSeconds(float duration)
    {
        var end = Time.time + duration; // Time.time is the time in seconds at the beginning of this frame since the start of the application (Read Only).
        while (Time.time < end) {
            transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
            yield return null; // Wait until the next frame & repeat until done
        }
    }*/
}

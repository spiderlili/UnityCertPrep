using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncAwaitShape : MonoBehaviour
{
    // Coroutine Example
    public IEnumerator RotateForSeconds(float duration)
    {
        var end = Time.time + duration; // Time.time is the time in seconds at the beginning of this frame since the start of the application (Read Only).
        while (Time.time < end) {
            transform.Rotate(new Vector3(1, 1) * Time.deltaTime * 150);
            yield return null; // Wait until the next frame & repeat until done
        }
    }
}

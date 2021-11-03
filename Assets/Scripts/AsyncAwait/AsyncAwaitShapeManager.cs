using UnityEngine;

public class AsyncAwaitShapeManager : MonoBehaviour
{
    [SerializeField] private AsyncAwaitShape[] shapes;
    public void BeginTestRotate()
    {
        // Coroutine example: each loop will add a bit more time
        for (var i = 0; i < shapes.Length; i++) {
            StartCoroutine(shapes[i].RotateForSeconds(1 + 1 * i));
        }
    }

}

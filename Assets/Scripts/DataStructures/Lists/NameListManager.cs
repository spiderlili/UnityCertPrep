using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameListManager : MonoBehaviour
{
    [SerializeField] private List<string> names = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        names.Add("Kate");
        names.Add("Anna");
        names.Add("Cory");
        names.Add("Beatrice");
        names.Add("Faye");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var nameToRemove = names[(Random.Range(0, names.Count))]; //temp variable
            names.Remove(nameToRemove);

            foreach (var name in names)
            {
                Debug.Log(name);
            }

            Debug.Log("name removed: " + nameToRemove);
        }
    }
}

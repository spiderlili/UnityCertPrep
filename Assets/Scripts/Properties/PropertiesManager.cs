using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestProperty
{
    PropertiesManager mg = new PropertiesManager();

    public void Test()
    {
        //mg.Speed = 5f; //error due to read only property
    }
}

public class PropertiesManager : MonoBehaviour
{
    public string Name { get; set; } 
    private float _speed; //read only

    public float SpeedAutoProperty { get; private set; } //auto property requires both the getter and setter

    public float Speed
    {
        get
        {
            return _speed; //access private data without changing it
        }

        private set
        {
            _speed = value;
        }
    }

    private void Start()
    {
        Speed = 10f;
        Debug.Log(Speed);
    }
}

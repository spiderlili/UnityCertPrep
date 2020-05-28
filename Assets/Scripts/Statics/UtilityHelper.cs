using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//static class cannot inherit from MonoBehaviour and be applied to objects, everything must also be static to work
public static class UtilityHelper 
{
    //create a primitive when hit the space key
    public static void CreateObject(GameObject obj)
    {
        GameObject.CreatePrimitive(PrimitiveType.Cube);
        //create a game object at randomised position
        obj.transform.position = new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
    }

    public static void SetPositionToZero(GameObject obj)
    {
        //option to add parameters: pass in an object as static methods have no references
        obj.transform.position = Vector3.zero;
    }

    public static void SetRandomColor(GameObject obj, Color color, bool isRandomColor = false)
    {
        if(isRandomColor == true) 
        {
            color = new Color(Random.value, Random.value, Random.value);
        }
        obj.GetComponent<Renderer>().material.SetColor("_Color", color);
    }
}

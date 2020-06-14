using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementInputSimple : MonoBehaviour
{
    [SerializeField] private float _horizontalSpeed = 1.0f;
    [SerializeField] private float _verticalSpeed = 1.0f;
    [SerializeField] private bool _disableVerticalInput = false;

    // Update is called once per frame - about 60 frames per second
    void Update()
    {
        //auto move cube to the right extremely quick: moving frames per second, 1m per frame => 60m per second
        //transform.Translate(Vector3.right); //new Vector3(1,0,0)

        //move to the right 1m per second: convert frame rate to seconds using Time.deltaTime and smooth out between frames
        //transform.Translate(Vector3.right * Time.deltaTime * _speed); 

        //use input auto-mapped to horizontal & vertical axis - assign to input manager
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(horizontalInput, 0, 0) * _horizontalSpeed * Time.deltaTime);

        if(_disableVerticalInput == true)
        {
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(0, verticalInput, 0) * _verticalSpeed * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes { 
    public class PlayerController : Shape
    {
        private GameSceneController gameSceneController;
       void Start()
        {
            //FindObjectOfType: generic function that finds and returns an instance of specified class
            gameSceneController = FindObjectOfType<GameSceneController>(); 
            SetColor(Color.yellow);
        }

    // Update is called once per frame
        void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            float horizontalMovement = Input.GetAxis("Horizontal");

            //test if L/R key is clicked, since value can be negative: use Abs and account for floating point precision
            if (Mathf.Abs(horizontalMovement) > Mathf.Epsilon) 
            {
                //keep movement smooth between frames
                horizontalMovement = horizontalMovement * Time.deltaTime * gameSceneController.playerSpeed;
                horizontalMovement += transform.position.x;
                transform.position = new Vector2(horizontalMovement, transform.position.y); //keep vertical pos the same
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes 
{ 
    public class PlayerController : Shape
    {
        private GameSceneController gameSceneController;
        public ProjectileController projectilePrefab;

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
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireProjectile();
            }
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

        private void FireProjectile()
        {
            Vector2 spawnPosition = transform.position;
            //create an instance of the object based on a prefab, set position and rotation
            ProjectileController projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            projectile.projectileSpeed = 2;
            projectile.projectileDirection = Vector2.up;
        }
    }
}

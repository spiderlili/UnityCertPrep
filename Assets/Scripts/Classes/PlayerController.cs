using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes 
{ 
    public class PlayerController : Shape
    {
        public ProjectileController projectilePrefab;
        private PlayerController player;

        protected override void Start()
        {
            base.Start();
            SetColor(Color.yellow);
            player = FindObjectOfType<PlayerController>(); //caching reference to make code more efficient
        }

    // Update is called once per frame
        void Update()
        {
            MovePlayer();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireProjectile();
                player.SetColor(Color.red);
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

                //limit player movement to be within screen bounds
                float right = gameSceneController.screenBounds.x - halfWidth;
                float left = -right;
                float limitHorizontalMovement = Mathf.Clamp(horizontalMovement, left, right);
                //if use horizontalMovement: it behaves fine
                transform.position = new Vector2(limitHorizontalMovement, transform.position.y); //keep vertical pos the same
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

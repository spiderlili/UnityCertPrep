using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dictionary{ 
    public class PlayerConnection 
    {
        public string name;
        public int id;
        
        public PlayerConnection(int id)
        {
            this.id = id;
        }
    }

    public class MainConnections : MonoBehaviour
    {
        //store a key value pair for players and have easy access to each of their names
        public Dictionary<int, PlayerConnection> playerDictionary = new Dictionary<int, PlayerConnection>();

        PlayerConnection p4;

        private void Start()
        {

            PlayerConnection p1 = new PlayerConnection(1);
            PlayerConnection p2 = new PlayerConnection(2);
            PlayerConnection p3 = new PlayerConnection(3);
            p4 = new PlayerConnection(4);

            playerDictionary.Add(p1.id, p1);
            p1.name = "Jay";
            playerDictionary.Add(p2.id, p2);
            p2.name = "Jane";
            playerDictionary.Add(p3.id, p3);
            p3.name = "Joy";
            playerDictionary.Add(p4.id, p4);
            p4.name = "Jake";
        }

        //loop through and print out all the names associated with it
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var player2 = playerDictionary[2];
                Debug.Log("Player name of id(2): " + player2.name);
                var player4 = playerDictionary[p4.id];
                Debug.Log("Player name of id(4): " + player4.name);
            }
        }
    }
}


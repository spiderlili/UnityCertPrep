using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace ColoradoOOP
{
    public class Listener : MonoBehaviour
    {
        private Invoker invoker;
        [SerializeField] private TMP_Text eventText;
        [SerializeField] private string messageToPrint = "I'm a listener!";
        void Start()
        {
            // Get access to the Invoker class by getting the Invoker component from the main camera 
            invoker = this.gameObject.GetComponent<Invoker>();
            
            // Add no argument PrintMessage() method as a listener
            invoker.AddNoArgumentListener(PrintMessageEventHandler);
        }

        // Handles the no argument event
        void PrintMessageEventHandler()
        {
            print(messageToPrint);
            eventText.text = messageToPrint;
        }
    }
}


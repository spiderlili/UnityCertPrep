using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ColoradoOOP
{
    public class Invoker : MonoBehaviour
    {
        // Copy one of the Timer scripts we've been using into the project. Declare fields for a timer and a no argument event object. 
        private Timer timer;
        private MessageEvent messageEvent;
        [SerializeField] private float messageRepeatDuration = 1.0f;
        private void Awake()
        {
            // Create an instance of the event object
            messageEvent = new MessageEvent();
        }

        public void AddNoArgumentListener(UnityAction listener)
        {
            // Add a no-argument UnityAction delegate as a listener
            messageEvent.AddListener(listener);
        }
        
        void Start()
        {
            // Add a Timer component, set its duration to 1 second, run the timer.
            timer = this.gameObject.AddComponent<Timer>();
            timer.Duration = messageRepeatDuration;
            timer.Run();
        }
        
        void Update()
        {
            // Invoke the event, run the timer again after it's finished.
            messageEvent.Invoke();
            if (timer.Finished) {
                timer.Run();
            }
        }
    }  
}


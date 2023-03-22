using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerButton : MonoBehaviour
{
    
        [SerializeField] float timeRemaining = 10;
        public bool timerIsRunning = false;
        public TextMeshProUGUI timeText;
        public GameObject timeObject;
        private void Start()
        {
            // Starts the timer automatically
        }
        void Update()
        {
            if (timerIsRunning)
            {
                if (timeRemaining > 0)
                {
                    timeRemaining -= Time.deltaTime;
                    DisplayTime(timeRemaining);
                }
                else
                {
                    Debug.Log("Time has run out!");
                    EnableCommand();
                    timeRemaining = 0;
                    timerIsRunning = false;
                    
                }
            }
        }
        void DisplayTime(float timeToDisplay)
        {
            timeToDisplay += 1;
            float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        void EnableCommand()
        {
            timeObject.SetActive(false);
            GetComponent<Button>().interactable = true;
            
        }  
       public void DisableCommand()
        {
            timerIsRunning = true;
            timeObject.SetActive(true);
            GetComponent<Button>().interactable = false;
        }

}
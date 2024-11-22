using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10; //Set Timer Length 
    public bool timerIsRunning = false; //Decide if the timer is running 
    public Text timeText;

    private void Start()
    {
        //Get Time Text
        timeText = GetComponent<Text>();

        // Starts the timer automatically 
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0) //Decrease Timer 
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else //Stop Timer
            {
                Debug.Log("Time has run out!"); //Output Time has run out 
                timeRemaining = 0; //Set Time to 0 
                timerIsRunning = false; //Stop the Timer from running 
            }
        }
        else 
        {
            timeText.text = string.Format("00:00");
        }
    }

    //Display Timer 
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; //Add Time to display 

        float seconds = Mathf.FloorToInt(timeToDisplay % 60); //Calculate Seconds Display 
        float milliSeconds = (timeToDisplay % 1) * 100; //Calculate Milliseconds Display 

        timeText.text = string.Format("{00:00}:{01:00}", seconds, milliSeconds); //Display Timer 
    }
} 


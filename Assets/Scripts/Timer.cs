using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public bool gameOver { private get; set; }
    public float runningTime { get; private set; }

    // Start is called before the first frame update
  

    // Update is called once per frame
    private void Update()
    {
            GameTimer();
 
    }
   
   private void GameTimer()
    {
        Debug.Log(gameOver);
        if (!gameOver)
        {
            runningTime = Time.timeSinceLevelLoad;

            float milliseconds = (Mathf.Floor(runningTime * 100) % 100); // calculate the milliseconds for the timer

            int seconds = (int)(runningTime % 60); // return the remainder of the seconds divide by 60 as an int
            runningTime /= 60; // divide current time y 60 to get minutes
            int minutes = (int)(runningTime % 60); //return the remainder of the minutes divide by 60 as an int

            timerText.text = string.Format("{0}:{1}:{2}", minutes.ToString("00"), seconds.ToString("00"), milliseconds.ToString("00"));
        }
        
    }

   
}

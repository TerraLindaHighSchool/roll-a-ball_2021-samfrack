using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    private bool gameOver = false;
    private float runningTime;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponentInChildren<TMPro.TextMeshProUGUI>(); // cache the text component
    }


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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameOver = true;
        }
    }
}

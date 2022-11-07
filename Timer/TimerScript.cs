using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerScript : MonoBehaviour
{
    public float timeRemaining = 10f;
    public bool timerIsRunning = false;
    public Text timeText;
    void Start()
    {
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning){
            if (timeRemaining > 0){
            timeRemaining -= Time.deltaTime;
            }else{
                Debug.Log("Time has ran out!!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
        void displayTime(float timeToDisplay){
            timeToDisplay += 1; 
            float minutes = Mathf.FloorToInt(timeToDisplay % 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

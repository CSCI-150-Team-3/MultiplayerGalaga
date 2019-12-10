using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class TimeCounter : MonoBehaviour
{
    Text timeUI; //reference to the UI Text

    float startTime; //start the gametime
    float ellapsedTime;
    bool startCounter;

    int minutes;
    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        startCounter = false;
        timeUI = GetComponent<Text>();
    }

    public void StartTimeCounter()
    {
        startTime = Time.time;
        startCounter = true;
    }

    public void StopTimeCounter()
    {
        startCounter = false;
    }
   
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex != 2)
        {
            StopTimeCounter();
            startTime = 0f;
            ellapsedTime = 0f;
        }
        else if (startCounter) { ellapsedTime = Time.time - startTime;

            minutes = (int)ellapsedTime / 60;
            seconds = (int)ellapsedTime % 60;

            //update the time counter UI Text
            timeUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            StartTimeCounter();
        }        
    }
}

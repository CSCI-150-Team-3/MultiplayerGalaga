using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3Complete : MonoBehaviour
{
    GameObject waveTwoAsteroid;
    GameObject waveThreeAsteroid;
    public GameObject rangeTrigger;
    public GameObject endWaveTrigger;
    float delayCounter = 2;

    void Update()
    {
        waveTwoAsteroid = GameObject.Find("PostWave2");
        if (waveTwoAsteroid == null)
        {
            delayCounter -= Time.deltaTime;

            if (delayCounter <= 0)
            {
                Destroy(rangeTrigger);
            }
        }
        waveThreeAsteroid = GameObject.Find("Large3 (93)");
        if(waveThreeAsteroid == null)
        {
            Destroy(endWaveTrigger);
        }
    }
}

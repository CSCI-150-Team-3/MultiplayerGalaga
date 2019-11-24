using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3Complete : MonoBehaviour
{
    GameObject waveTwoAsteroid;
    public GameObject rangeTrigger;
    float delayCounter = 3;

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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave4Complete : MonoBehaviour
{
    GameObject positionTrigger;
    public GameObject waveStart;
    float delayCounter = 2.5f;

    void Update()
    {
        positionTrigger = GameObject.Find("Wave3");
        if(positionTrigger == null)
        {
            delayCounter -= Time.deltaTime;
            if(delayCounter <= 0)
            {
                Destroy(waveStart);
            }
        }
    }
}

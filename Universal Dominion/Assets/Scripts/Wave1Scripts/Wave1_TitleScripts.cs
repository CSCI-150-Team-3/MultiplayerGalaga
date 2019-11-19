using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1_TitleScripts : MonoBehaviour
{
    float delaycounter = 0.25f;
    public GameObject readyPrefab;
    public GameObject wavePrefab;
    public GameObject incomingPrefab;
    GameObject readySprite;
    GameObject waveSprite;
    GameObject incomingSprite;
    GameObject waveOneEnd;
    bool Ready = true;
    bool Wave = false;
    bool Wave1 = true;
    bool postWave1 = false;
    
     void Update()
    {
        delaycounter -= Time.deltaTime;

        if (delaycounter <= 0 && Ready && !Wave)
        {
            waveSprite = (GameObject)Instantiate(wavePrefab, transform.position, Quaternion.identity);
            delaycounter = 2;
            Ready = false;
        }

        if (delaycounter <= 0 && !Ready && !Wave)
        {
            waveSprite.SetActive(false);
            readySprite = (GameObject)Instantiate(readyPrefab, transform.position, Quaternion.identity);
            delaycounter = 2;
            Wave = true;
        }

        waveOneEnd = GameObject.Find("Wave1");
        if (delaycounter <= 0 && Wave && waveOneEnd != null)
        {
            readySprite.SetActive(false);
        }

        if (waveOneEnd == null && Wave1)
        {
            incomingSprite = (GameObject)Instantiate(incomingPrefab, transform.position, Quaternion.identity);
            delaycounter = 2;
            Wave1 = false;
        }

        if(delaycounter <= 0 && !Wave1 && !postWave1)
        {
            incomingSprite.SetActive(false);
            readySprite.SetActive(true);
            delaycounter = 2;
            postWave1 = true;
        }

        if (delaycounter <= 0 && postWave1)
        {
            readySprite.SetActive(false);
        }
    }

}

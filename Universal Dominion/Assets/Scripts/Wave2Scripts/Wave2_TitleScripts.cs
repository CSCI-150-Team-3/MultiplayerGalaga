using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2_TitleScripts : MonoBehaviour
{
    float delaycounter = 0.25f;
    public GameObject readyPrefab;
    public GameObject wavePrefab;
    public GameObject incomingPrefab;
    GameObject readySprite;
    GameObject waveSprite;
    GameObject incomingSprite;
    GameObject waveOneEnd;
    GameObject waveTwoEnd;
    bool Ready = true;
    bool WaveBegin = true;
    bool PostWave = false;
    bool Asteroids = true;
    bool AsteroidsEnd = false;

    void Update()
    {
        delaycounter -= Time.deltaTime;
        waveOneEnd = GameObject.Find("PostWave1");
        if (delaycounter <= 0 && waveOneEnd == null && WaveBegin)
        {
            waveSprite = (GameObject)Instantiate(wavePrefab, transform.position, Quaternion.identity);
            delaycounter = 2;
            WaveBegin = false;
        }

        if (delaycounter <= 0 && !WaveBegin && !PostWave)
        {
            waveSprite.SetActive(false);
            readySprite = (GameObject)Instantiate(readyPrefab, transform.position, Quaternion.identity);
            delaycounter = 2;
            PostWave = true;
        }

        if (delaycounter <= 0 && PostWave && Asteroids)
        {
            readySprite.SetActive(false);
        }

        waveTwoEnd = GameObject.Find("Wave2");
        if (waveTwoEnd == null && Asteroids)
        {
            incomingSprite = (GameObject)Instantiate(incomingPrefab, transform.position, Quaternion.identity);
            delaycounter = 2;
            Asteroids = false;
        }

        if(delaycounter <=0 && !Asteroids && !AsteroidsEnd)
        {
            incomingSprite.SetActive(false);
            readySprite.SetActive(true);
            delaycounter = 2;
            AsteroidsEnd = true;
        }

        if (AsteroidsEnd && delaycounter <= 0)
        {
            readySprite.SetActive(false);
        }
    }
}

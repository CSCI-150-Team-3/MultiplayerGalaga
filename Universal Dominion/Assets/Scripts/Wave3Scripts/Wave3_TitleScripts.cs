using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3_TitleScripts : MonoBehaviour
{
    float delaycounter = 0.25f;
    public GameObject readyPrefab;
    public GameObject wavePrefab;
    public GameObject allRangePrefab;
    GameObject readySprite;
    GameObject waveSprite;
    GameObject allRangeSprite;
    GameObject waveTwoEnd;
    GameObject preWaveTwoEnd;
    bool WaveEnd = true;
    bool WaveBegin = true;
    bool PostWave = false;

    void Update()
    {
        delaycounter -= Time.deltaTime;
        preWaveTwoEnd = GameObject.Find("PostWave2");
        if(WaveEnd && preWaveTwoEnd == null)
        {
            allRangeSprite = (GameObject)Instantiate(allRangePrefab, transform.position, Quaternion.identity);
            WaveEnd = false;
        }
        waveTwoEnd = GameObject.Find("allRangeTrigger");
        if (delaycounter <= 0 && waveTwoEnd == null && WaveBegin)
        {
            allRangeSprite.SetActive(false);
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

        if (delaycounter <= 0 && PostWave)
        {
            readySprite.SetActive(false);
        }
    }
}

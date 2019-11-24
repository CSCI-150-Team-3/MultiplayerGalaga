using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave4_TitleScripts : MonoBehaviour
{
    float delaycounter = 0.25f;
    public GameObject readyPrefab;
    public GameObject wavePrefab;
    GameObject readySprite;
    GameObject waveSprite;
    GameObject waveThreeEnd;
    bool WaveBegin = true;
    bool PostWave = false;

    void Update()
    {
        delaycounter -= Time.deltaTime;
        waveThreeEnd = GameObject.Find("trenchRangeTrigger");
        if (delaycounter <= 0 && waveThreeEnd == null && WaveBegin)
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

        if (delaycounter <= 0 && PostWave)
        {
            readySprite.SetActive(false);
        }
    }
}

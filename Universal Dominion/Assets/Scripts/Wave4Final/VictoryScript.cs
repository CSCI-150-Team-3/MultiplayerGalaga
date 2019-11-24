using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    float delaycounter = 2;
    public GameObject victoryPrefab;
    GameObject victorySprite;
    GameObject bossWaveEnd;
    bool WaveEnd = true;

    private void Update()
    {

        bossWaveEnd = GameObject.Find("Boss");
        if (bossWaveEnd == null)
        {
            delaycounter -= Time.deltaTime;

            if (delaycounter <= 0 && WaveEnd)
            {
                victorySprite = (GameObject)Instantiate(victoryPrefab, transform.position, Quaternion.identity);
                delaycounter = 2;
                WaveEnd = false;
            }
        }
    }
}

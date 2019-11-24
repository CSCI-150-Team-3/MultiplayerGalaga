using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave2Complete : MonoBehaviour
{
    GameObject seekFinalShipTop;
    GameObject seekFinalShipBottom;
    GameObject seekFinalAsteroid;

    public GameObject postWave2Prefab;
    public GameObject wave2Prefab;
    bool endWave2 = true;
    bool endPostWave2 = true;

    void Update()
    {
        seekFinalShipTop = GameObject.Find("TopEnemy");
        seekFinalShipBottom = GameObject.Find("BottomEnemy");
        if(seekFinalShipTop == null && seekFinalShipBottom == null && endWave2)
        {
            Destroy(wave2Prefab);
            endWave2 = false;
        }

        seekFinalAsteroid = GameObject.Find("AsteroidMed (29)");
        if(seekFinalAsteroid == null && endPostWave2)
        {
            Destroy(postWave2Prefab);
            endPostWave2 = false;
        }
    }
}

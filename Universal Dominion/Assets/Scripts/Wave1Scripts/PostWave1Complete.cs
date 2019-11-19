using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostWave1Complete : MonoBehaviour
{
    float delayCounter = 13f;
    public GameObject wave1Prefab;
    GameObject seekFinalShip;

    void Update()
    {
        seekFinalShip = GameObject.Find("FrontEnemy");
        if (seekFinalShip == null)
        {
            seekFinalShip = GameObject.Find("2ndLineEnemy");
            if (seekFinalShip == null)
            {
                seekFinalShip = GameObject.Find("3rdLineEnemy");
                if (seekFinalShip == null)
                {
                    seekFinalShip = GameObject.Find("RearEnemy");
                    if (seekFinalShip == null)
                    {
                        delayCounter -= Time.deltaTime;
                        if (delayCounter <= 0)
                        {
                            Destroy(wave1Prefab);
                        }
                    }
                }
            }        
        }
    }
}

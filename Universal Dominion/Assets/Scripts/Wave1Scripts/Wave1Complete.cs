using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1Complete : MonoBehaviour
{
    float delayCounter = 6;
    public GameObject wave1Prefab;
    GameObject seekFinalShip;

    void Update()
    {
        delayCounter -= Time.deltaTime;
        if (delayCounter <= 0)
        {
            seekFinalShip = GameObject.Find("FrontEnemy");
            if(seekFinalShip == null)
            {
                seekFinalShip = GameObject.Find("2ndLineEnemy");
                if(seekFinalShip == null)
                {
                    seekFinalShip = GameObject.Find("3rdLineEnemy");
                    if(seekFinalShip == null)
                    {
                        seekFinalShip = GameObject.Find("RearEnemy");
                        if(seekFinalShip == null)
                        {
                            Destroy(wave1Prefab);                         
                        }
                    }
                }

            }
        }
    }
}

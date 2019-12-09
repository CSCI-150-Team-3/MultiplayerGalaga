using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1Complete : MonoBehaviour
{
    float delayCounter = 6;
    public GameObject wave1Prefab;
    public GameObject postWavePrefab;
    GameObject seekFinalShip;
    bool wave1 = true;
    bool postwave1 = false;

    void Update()
    {
        delayCounter -= Time.deltaTime;
        if (delayCounter <= 0 && wave1)
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
                            Destroy(wave1Prefab);
                            delayCounter = 5;
                            wave1 = false;
                            postwave1 = true;
                        }
                    }
                }

            }
        }
        if (delayCounter <= 0 && postwave1)
        {
            seekFinalShip = GameObject.Find("AsteroidSmall");
            if (seekFinalShip == null)
            {
                seekFinalShip = GameObject.Find("AsteroidSmall1");
                if (seekFinalShip == null)
                {
                    seekFinalShip = GameObject.Find("AsteroidSmall2");
                    if (seekFinalShip == null)
                    {
                        seekFinalShip = GameObject.Find("AsteroidSmall3");
                        if (seekFinalShip == null)
                        {
                            seekFinalShip = GameObject.Find("AsteroidSmall5");
                            if (seekFinalShip == null)
                            {
                                seekFinalShip = GameObject.Find("AsteroidSmall6");
                                if (seekFinalShip == null)
                                {
                                    seekFinalShip = GameObject.Find("AsteroidSmall7");
                                    if (seekFinalShip == null)
                                    {
                                        seekFinalShip = GameObject.Find("AsteroidSmall9");
                                        if (seekFinalShip == null)
                                        {
                                            Destroy(postWavePrefab);
                                            postwave1 = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
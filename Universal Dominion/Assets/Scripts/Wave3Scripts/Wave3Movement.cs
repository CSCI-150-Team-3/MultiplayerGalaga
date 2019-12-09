using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3Movement : MonoBehaviour
{
    public GameObject Asteroid;
    public float delaycounter = 4.25f;
    float asteroidBoundary = 0.5f;

    GameObject waveTwoEnd;

    void Update()
    {
        waveTwoEnd = GameObject.Find("allRangeTrigger");

        if (waveTwoEnd == null)
        {
            delaycounter -= Time.deltaTime;

            if (delaycounter <= 0)
            {
                Vector3 posx = transform.position;
                posx.x += 0 * Time.deltaTime;
                transform.position = posx;

                Vector3 posy = transform.position;
                posy.y -= 2 * Time.deltaTime;
                transform.position = posy;

                if (posy.y + asteroidBoundary < -5)
                {
                    Destroy(Asteroid);
                }
            }

        }
    }
}

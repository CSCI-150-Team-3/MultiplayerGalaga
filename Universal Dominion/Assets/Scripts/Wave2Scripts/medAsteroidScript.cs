using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class medAsteroidScript : MonoBehaviour
{
    public GameObject medAsteroid;
    public float delaycounter = 4.25f;
    float asteroidBoundary = 0.5f;

    GameObject waveTwoEnd;

    void Update()
    {
        waveTwoEnd = GameObject.Find("Wave2");

        if (waveTwoEnd == null)
        {
            delaycounter -= Time.deltaTime;

            if (delaycounter <= 0)
            {
                Vector3 posx = transform.position;
                posx.x -= 3 * Time.deltaTime;
                transform.position = posx;

                Vector3 posy = transform.position;
                posy.y -= 3 * Time.deltaTime;
                transform.position = posy;

                if (posy.y + asteroidBoundary < -5)
                {
                    Destroy(medAsteroid);
                }
            }

        }
    }
}

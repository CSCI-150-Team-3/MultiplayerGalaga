using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemyScript : MonoBehaviour
{
    bool Spawn = true;
    float delayCounter = 0.5f;
    bool left = true;
    GameObject seekTrigger;

    void Update()
    {
        seekTrigger = GameObject.Find("Opening");
        if (seekTrigger == null)
        {
            delayCounter -= Time.deltaTime;

            if (Spawn && delayCounter <= 0)
            {
                Vector3 posx = transform.position;
                posx.x += 0;
                transform.position = posx;

                Vector3 posy = transform.position;
                posy.y -= 3 * Time.deltaTime;

                if (posy.y <= 0)
                {
                    posy.y = 0;
                    Spawn = false;
                    delayCounter = 11;
                }

                transform.position = posy;
            }

            if (!Spawn)
            {
                delayCounter -= Time.deltaTime;
                Vector3 posx = transform.position;

                if (delayCounter <= 0)
                {
                    delayCounter = 10;
                    left = !left;
                }

                if (left)
                {
                    posx.x -= 1 * Time.deltaTime;
                    transform.position = posx;
                }

                if (!left)
                {
                    posx.x += 1 * Time.deltaTime;
                    transform.position = posx;
                }
            }
        }
    }
}

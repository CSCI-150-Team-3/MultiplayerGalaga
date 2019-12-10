using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontEnemyScript : MonoBehaviour
{
    bool Spawn = true;
    float delayCounter = 5.5f;
    bool left = true;
    GameObject seekTrigger;

    void Update()
    {
        seekTrigger = GameObject.Find("Opening");
        if (seekTrigger == null)
        {
            if (Spawn)
            {
                Vector3 posx = transform.position;
                posx.x += 0;
                transform.position = posx;

                Vector3 posy = transform.position;
                posy.y -= 3 * Time.deltaTime;

                if (posy.y <= -2)
                {
                    posy.y = -2;
                    Spawn = false;
                }

                transform.position = posy;
            }

            if (!Spawn)
            {
                delayCounter -= Time.deltaTime;
                Vector3 posx = transform.position;

                if (delayCounter <= 0)
                {
                    delayCounter = 5;
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

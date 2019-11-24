using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopEnemyScript : MonoBehaviour
{
    bool Spawn = true;
    public float delayCounter = 4f;
    public float waveCounter = 6f;
    bool left = true;
    GameObject seekTrigger;
    Transform player;

    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Player_Ship");
            if(go != null)
            {
                player = go.transform;

            }
        }
        if(player == null)
        {
            return;
        }

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);

        seekTrigger = GameObject.Find("PostWave1");
        if (seekTrigger == null)
        {
            delayCounter -= Time.deltaTime;
                      
            if (delayCounter <= 0)
            {
                waveCounter -= Time.deltaTime;

                Vector3 posx = transform.position;

                if (waveCounter <= 0)
                {
                    waveCounter = 3;
                    left = !left;
                }

                if (left)
                {
                    posx.x -= 3 * Time.deltaTime;
                    transform.position = posx;
                }

                if (!left)
                {
                    posx.x += 3 * Time.deltaTime;
                    transform.position = posx;
                }
            }
        }
    }
}

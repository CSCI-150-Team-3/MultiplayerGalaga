using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    Transform player;

    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("Player_Ship");
            if (go != null)
            {
                player = go.transform;

            }
        }
        if (player == null)
        {
            return;
        }

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, zAngle);
    }
}
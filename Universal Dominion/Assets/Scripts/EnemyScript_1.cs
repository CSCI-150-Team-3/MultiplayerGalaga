using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript_1 : MonoBehaviour
{
    public float maxSpeed = 1f;
    float shipBoundaryRadius = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 posx = transform.position;
        posx.x += maxSpeed * 0;
        transform.position = posx;

        Vector3 posy = transform.position;
        posy.y -= maxSpeed * Time.deltaTime;

        //Restrict player to Screen Boundaries
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float heightOrthographic = 5;
            
        if (posy.y + shipBoundaryRadius < -heightOrthographic)
            posy.y = heightOrthographic + shipBoundaryRadius;

        transform.position = posy;
    }
}

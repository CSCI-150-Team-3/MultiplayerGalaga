using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour  //includes player spawning!!!
{
    public float maxSpeed = 5f;
    float shipBoundaryRadius = 0.5f;
    bool beginning = true;
    bool forward = true;
    
    void Update()
    {
        if (beginning && forward)
        {
            Vector3 posx = transform.position;
            posx.x = 0;
            transform.position = posx;

            Vector4 posy = transform.position;
            posy.y += 3 * Time.deltaTime;
            transform.position = posy;

            if (posy.y >= -3)
            {
                forward = false;
            }
        }
        if (beginning && !forward)
        {
            Vector3 posx = transform.position;
            posx.x = 0;
            transform.position = posx;

            Vector4 posy = transform.position;
            posy.y -= 1 * Time.deltaTime;
            transform.position = posy;

            if (posy.y <= -4)
            {
                posy.y = -4;
                transform.position = posy;
                beginning = false;
            }
        }
        if (!beginning)
        {
            Vector3 posx = transform.position;
            posx.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
            transform.position = posx;

            Vector4 posy = transform.position;
            posy.y += Input.GetAxis("Vertical") * maxSpeed * 0;
            transform.position = posy;

            //Restrict player to Screen Boundaries
            float screenRatio = (float)Screen.width / (float)Screen.height;
            float widthOrthographic = Camera.main.orthographicSize * screenRatio;

            if (posx.x + shipBoundaryRadius > widthOrthographic)
                posx.x = widthOrthographic - shipBoundaryRadius;

            if (posx.x - shipBoundaryRadius < -widthOrthographic)
                posx.x = -widthOrthographic + shipBoundaryRadius;

            transform.position = posx;
        }
    }
}

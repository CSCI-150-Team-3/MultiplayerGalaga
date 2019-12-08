using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour  //includes player spawning!!!
{
    public float maxSpeed = 5f;
    float shipBoundaryRadius = 0.5f;
    bool beginning = true;
    bool forward = true;

    GameObject Wave3Start;
    GameObject AllRangeStart;
    GameObject Wave3End;
    bool allRangePrep = false;
    bool allRangeMode = false;
    bool trenchRangePrep = false;
    bool trenchRangeMode = false;

    void Update()
    {
        Wave3Start = GameObject.Find("PostWave2");
        AllRangeStart = GameObject.Find("AllRangePrep");
        Wave3End = GameObject.Find("Wave3");

        if (Wave3Start == null && !allRangePrep && Wave3End !=null)
        {
            allRangePrep = true;
        }
        if (beginning && forward && !allRangePrep && Wave3End != null)
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
        if (beginning && !forward && !allRangePrep)
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
        if (!beginning && !allRangePrep)
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
        if (allRangePrep && !allRangeMode)
        {
            Vector3 posx = transform.position;
            Vector4 posy = transform.position;
            if(posy.y <= 0)
            {
                posy.y += 3 * Time.deltaTime;
                if(posy.y > 0)
                {
                    posy.y = 0;
                }
                transform.position = posy;
            }
            if(posx.x != 0)
            {
                if(posx.x >= 1)
                {
                    posx.x -= 3 * Time.deltaTime;
                }
                if(posx.x <= -1)
                {
                    posx.x += 3 * Time.deltaTime;
                }
                if(posx.x > -1.1 && posx.x < 1.1)
                {
                    posx.x = 0;
                }
                transform.position = posx;
            }
            if(posx.x == 0 && posy.y == 0)
            {
                allRangeMode = true;
            }
     
        }
        if (allRangeMode)
        {
            Vector3 posx = transform.position;
            posx.x += Input.GetAxis("Horizontal") * maxSpeed * Time.deltaTime;
            transform.position = posx;

            Vector4 posy = transform.position;
            posy.y += Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime;
            transform.position = posy;

            float screenRatio = (float)Screen.width / (float)Screen.height;
            float widthOrthographic = Camera.main.orthographicSize * screenRatio;

            if (posx.x + shipBoundaryRadius > widthOrthographic)
                posx.x = widthOrthographic - shipBoundaryRadius;

            if (posx.x - shipBoundaryRadius < -widthOrthographic)
                posx.x = -widthOrthographic + shipBoundaryRadius;

            if (posy.y + shipBoundaryRadius > 5)
                posy.y = 5 - shipBoundaryRadius;

            if (posy.y - shipBoundaryRadius < -4)
                posy.y = -4 + shipBoundaryRadius;


            transform.position = posx;
            transform.position = posy;
        }
        if(Wave3End == null && !trenchRangeMode)
        {
            allRangePrep = false;
            allRangeMode = false;
            trenchRangePrep = true;
            beginning = true;
        }
        if(trenchRangePrep)
        {
            Vector3 posx = transform.position;
            Vector4 posy = transform.position;
            if (posy.y >= -4)
            {
                posy.y -= 3 * Time.deltaTime;
                if (posy.y < -4)
                {
                    posy.y = -4;
                }
                transform.position = posy;
            }
            if (posx.x != 0)
            {
                if (posx.x >= 1)
                {
                    posx.x -= 3 * Time.deltaTime;
                }
                if (posx.x <= -1)
                {
                    posx.x += 3 * Time.deltaTime;
                }
                if (posx.x > -1.1 && posx.x < 1.1)
                {
                    posx.x = 0;
                }
                transform.position = posx;
            }
            if (posx.x == 0 && posy.y == -4)
            {
                trenchRangePrep = false;
                trenchRangeMode = true;
                beginning = false;
            }
        }

    }
}

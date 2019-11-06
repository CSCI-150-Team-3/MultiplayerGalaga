using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovementNet : NetworkBehaviour
{
    public float maxSpeed = 5f;
    float shipBoundaryRadius = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }


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

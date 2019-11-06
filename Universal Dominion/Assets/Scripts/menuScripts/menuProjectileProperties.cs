using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuProjectileProperties : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float lifeTimer = 2f;
    public bool fireLeft;

    void Update()
    {
        Vector3 posy = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);

        if(fireLeft)
        {
            posy -= transform.rotation * velocity;
        }
        else
        {
            posy += transform.rotation * velocity;
        }

        transform.position = posy;

        lifeTimer -= Time.deltaTime;

       if (lifeTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}

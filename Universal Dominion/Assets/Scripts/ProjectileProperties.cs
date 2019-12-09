using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileProperties : MonoBehaviour
{
    public float maxSpeed = 5f;
    public float timer = 2f;

    void Update()
    {
        Vector3 posy = transform.position;
        Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
        posy += transform.rotation * velocity;

        transform.position = posy;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.6f, 0);

    GameObject startPlayer;
    public GameObject bulletPrefab;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    void Update()
    {
        startPlayer = GameObject.Find("Opening");
        cooldownTimer -= Time.deltaTime;

        if (startPlayer == null)
        {
            if (Input.GetButton("Fire1") && cooldownTimer <= 0)
            {
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * bulletOffset;
                Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            }
        }
    }
}

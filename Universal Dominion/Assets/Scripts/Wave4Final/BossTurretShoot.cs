using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurretShoot : MonoBehaviour
{
    public Vector3 bulletOffset1 = new Vector3(-0.05f, 0.7f, 0);
    public Vector3 bulletOffset2 = new Vector3(0.05f, 0.7f, 0);

    public GameObject bulletPrefab;
    public float fireDelay = 0.1f;
    float cooldownTimer = 0f;
    float fireTimer = 0f;
    float peaceTimer = 3f;

    public AudioClip SoundEffect;
    public AudioSource SoundSource;

    void Start()
    {
        cooldownTimer = fireDelay;
        SoundSource.clip = SoundEffect;
    }

    void Update()
    {
        Vector4 posy = transform.position;
        peaceTimer -= Time.deltaTime;

        if (posy.y <= 5 && peaceTimer <= 0)
        {
            fireTimer -= Time.deltaTime;
            cooldownTimer -= Time.deltaTime;

            if (cooldownTimer <= 0)
            {
                cooldownTimer = fireDelay;

                Vector3 offset = transform.rotation * bulletOffset1;
                Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
                offset = transform.rotation * bulletOffset2;
                Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

                SoundSource.Play();
            }
            if (fireTimer <= 0)
            {
                peaceTimer = 3;
                fireTimer = 1;
            }
        }
    }
}

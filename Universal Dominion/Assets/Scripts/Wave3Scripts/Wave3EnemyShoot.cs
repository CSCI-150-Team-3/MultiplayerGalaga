using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave3EnemyShoot : MonoBehaviour
{
    public Vector3 bulletOffset1 = new Vector3(-0.25f, 0.6f, 0);
    public Vector3 bulletOffset2 = new Vector3(0.25f, 0.6f, 0);

    public GameObject bulletPrefab;
    public float fireDelay = 0.5f;
    float cooldownTimer = 0f;

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
        if (posy.y <= 5)
        {
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
        }
    }
}

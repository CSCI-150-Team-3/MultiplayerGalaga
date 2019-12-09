using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Vector3 bulletOffset = new Vector3(0, 0.6f, 0);

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
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0)
        {
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;
            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);

            SoundSource.Play();
        }

    }
}

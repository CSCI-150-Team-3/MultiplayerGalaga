using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileAudio : MonoBehaviour
{
    public AudioClip SoundEffect;
    public AudioSource SoundSource;

    public float soundDelay = 0.25f;
    float soundTimer = 0;

    void Start()
    {
        SoundSource.clip = SoundEffect;
    }

    void Update()
    {
        soundTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && soundTimer <= 0)
        {
            soundTimer = soundDelay;

            SoundSource.Play();
        }
    }
}

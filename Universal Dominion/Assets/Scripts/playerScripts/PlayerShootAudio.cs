using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootAudio : MonoBehaviour
{
    public AudioClip SoundEffect;
    public AudioSource SoundSource;
    public float fireDelay = 0.33f;
    GameObject player;
    float ProjectileCool;

    void Start()
    {
        SoundSource.clip = SoundEffect;

    }

    void Update()
    {
        player = GameObject.Find("Opening");
        ProjectileCool -= Time.deltaTime;

        if (player == null)
        {
            if (Input.GetButton("Fire1") && ProjectileCool <= 0)
            {
                SoundSource.Play();
                ProjectileCool = fireDelay;
            }
        }
    }
}

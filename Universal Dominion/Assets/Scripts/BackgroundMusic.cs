using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip SoundEffect;
    public AudioSource SoundSource;

    void Start()
    {
        SoundSource.clip = SoundEffect;
        SoundSource.Play();
    }

}

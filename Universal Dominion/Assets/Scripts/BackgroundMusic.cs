using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip SoundEffect;
    public AudioClip VictoryEffect;
    public AudioSource SoundSource;
    bool Round_1 = false;
    bool Victory = false;

    void Start()
    {
        SoundSource.clip = SoundEffect;
        SoundSource.Play();
    }

    void Update()
    {
        GameObject enemies = GameObject.Find("Enemy_1");
        if(enemies == null && !Round_1)
        {
            SoundSource.Stop();
            SoundSource.clip = VictoryEffect;
            Round_1 = true;
        }
        if(Round_1 && !Victory)
        {
            SoundSource.Play();
            Victory = true;
        }
    }
}

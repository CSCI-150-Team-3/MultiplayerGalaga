using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    GameObject EndWave3;
    GameObject EndPosition;
    GameObject Boss;
    public AudioClip SoundEffect;
    public AudioClip BossEffect;
    public AudioClip VictoryEffect;
    public AudioSource SoundSource;
    bool changeMusic = true;
    bool playMusic = true;
    bool endGame = true;
    bool victory = false;
    float delayCounter;

    void Start()
    {
        SoundSource.clip = SoundEffect;
        SoundSource.Play();
    }

    private void Update()
    {
        delayCounter -= Time.deltaTime;
        EndWave3 = GameObject.Find("Wave3");
        EndPosition = GameObject.Find("trenchRangeTrigger");
        Boss = GameObject.Find("Boss");

        if(EndWave3 == null && changeMusic)
        {
            SoundSource.Stop();
            SoundSource.clip = BossEffect;
            changeMusic = false;
        }

        if(EndPosition == null && playMusic)
        {
            SoundSource.Play();
            playMusic = false;
        }

        if(Boss == null && endGame)
        {
            SoundSource.Stop();
            SoundSource.clip = VictoryEffect;
            endGame = false;
            victory = true;
            delayCounter = 2;
        }
        if(Boss == null && delayCounter <= 0 && victory)
        {
            SoundSource.Play();
            victory = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : MonoBehaviour
{
    GameObject scoreUITextGO;

    public int health = 1;
    public int scoremultiplier = 1;
    public float invulnerabilityPeriod;
    float invulnerableTimer = 0;
    int correctLayer;

    void Start()
    {
        correctLayer = gameObject.layer;
        scoreUITextGO = GameObject.FindGameObjectWithTag("ScoreTextTag");
    }

    void OnTriggerEnter2D()
    {
        health--;
        invulnerableTimer = invulnerabilityPeriod;
        gameObject.layer = 10;
    }
    void Update()
    {
        invulnerableTimer -= Time.deltaTime;
        if (invulnerableTimer <= 0)
        {
            gameObject.layer = correctLayer;
        }
        {
            if (health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        //add points to score
        scoreUITextGO.GetComponent<GameScore>().Score += (scoremultiplier * 100);
        Destroy(gameObject);
    }
}

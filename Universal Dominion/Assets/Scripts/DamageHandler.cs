using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;
    public float invulnerabilityPeriod;
    float invulnerableTimer = 0;
    int correctLayer;

    void Start()
    {
        correctLayer = gameObject.layer;
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
            if(health <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public int health = 1;
    public float invulnerabilityPeriod;
    float invulnerableTimer = 0;
    int correctLayer;
    public Animator blink;

    void Start()
    {
        correctLayer = gameObject.layer;
    }

    void OnTriggerEnter2D()
    {
        blink.SetFloat("Damage", 1f);
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
            blink.SetFloat("Damage", 0f);

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
        Destroy(gameObject);
    }
}

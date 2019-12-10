using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningScene : MonoBehaviour
{
    public GameObject endTrigger;
    float delayCounter = 4.25f;

    void Update()
    {
        delayCounter -= Time.deltaTime;
        if (delayCounter <= 0)
        {
            Die();
        }
    }
  void Die()
    {
        Destroy(endTrigger);
    }
}

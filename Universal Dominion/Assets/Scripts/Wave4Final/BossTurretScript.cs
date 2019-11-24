using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurretScript : MonoBehaviour
{
    GameObject TheBoss;
    public GameObject TheTurret;

    void Update()
    {
        TheBoss = GameObject.Find("Boss");
        if(TheBoss == null)
        {
            Destroy(TheTurret);
        }
    }
}

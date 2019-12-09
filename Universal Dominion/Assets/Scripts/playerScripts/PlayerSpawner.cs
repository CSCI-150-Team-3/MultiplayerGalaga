using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerPrefab;
    GameObject seekShip;
    GameObject playerInstance;

    float respawnTimer = 2;

    void Start()
    {
        
    }

    void Update()
    {
        seekShip = GameObject.Find("Player_Ship");
        if ( seekShip == null)
        {
            respawnTimer -= Time.deltaTime;

            if (respawnTimer <= 0)
            {
                SpawnPlayer();
            }
        }
    }
    void SpawnPlayer()
    {
        respawnTimer = 2;
        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.name = "Player_Ship";
    }
}

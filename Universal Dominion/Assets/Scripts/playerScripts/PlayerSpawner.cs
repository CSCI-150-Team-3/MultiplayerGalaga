using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerSpawner : MonoBehaviour
{
    public GameObject TimeCounterGO;
    public GameObject playerPrefab;
    GameObject seekShip;
    GameObject playerInstance;
    //experimental
    public Hullbar hull;
    GameObject seekHull;
    //experimental

    float respawnTimer = 2;

    public Text LivesUIText;

    int LivesUsed = 0; //variable for number of player lives used.



    void Start()
    {
        hull.GetComponent<Hullbar>();
        TimeCounterGO.GetComponent<TimeCounter>().StartTimeCounter();
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
        LivesUsed += 1;
        LivesUIText.text = LivesUsed.ToString(); //update the lives used UI

        playerInstance = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        playerInstance.name = "Player_Ship";
    }
}

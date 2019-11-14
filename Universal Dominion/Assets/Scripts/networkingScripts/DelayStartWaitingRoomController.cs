using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DelayStartWaitingRoomController : MonoBehaviourPunCallbacks
{
    private PhotonView myPhotonView;

    [SerializeField]
    private int multiplayerSceneIndex;
    [SerializeField]
    private int menuSceneIndex;

    private int playerCount;
    private int roomSize;

    [SerializeField]
    private int minPlayersToStart;

    //text variables for holding the displays for the countdown timer and playercount
    [SerializeField]
    private Text roomCountDisplay;
    [SerializeField]
    private Text timerToStartDisplay;

    //boolean values to trigger certain events
    private bool readyToCountDown;
    private bool readyToStart;
    private bool startingGame;

    //countdown timer variables
    private float timerToStartGame;
    private float notFullGameTimer;
    private float fullGameTimer;

    //countdown timer reset variables
    [SerializeField]
    private float maxFullGameWaitTime;
    [SerializeField]
    private float maxWaitTime;

    private void Start()
    {
        //Initialize Variables
        myPhotonView = GetComponent<PhotonView>();
        fullGameTimer = maxFullGameWaitTime;
        notFullGameTimer = maxWaitTime;
        timerToStartGame = maxWaitTime;

        PlayerCountUpdate();
    }

    void PlayerCountUpdate()
    {
        //updates player count when players join/leave a room
        //displays player count on screen
        //triggers countdown timer
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        roomCountDisplay.text = playerCount + ":" + roomSize;

        if(playerCount == roomSize)
        {
            readyToStart = true;
        }
        else if(playerCount >= minPlayersToStart)
        {
            readyToCountDown = true;
        }
        else
        {
            readyToCountDown = false;
            readyToStart = false;
        }

    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        //called when a new player joins a room
        PlayerCountUpdate();

        //Sync and send the host countdown timer to all other players
        if (PhotonNetwork.IsMasterClient)
        {
            myPhotonView.RPC("RPC_SyncTimer", RpcTarget.Others, timerToStartGame);
        }
    }

    [PunRPC]
    private void RPC_SyncTimer(float timeIn)
    {
        //RPC to sync the countdown timer for people joining after the clock has started counting down
        timerToStartGame = timeIn;
        notFullGameTimer = timeIn;

        if(timeIn < fullGameTimer)
        {
            fullGameTimer = timeIn;
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //called whenever a player leaves the room
        PlayerCountUpdate();
    }

    public void Update()
    {
        WaitingForMorePlayers();
    }

    void WaitingForMorePlayers()
    {
        //timer stops and resets if only one player is present in the room
        if (playerCount <= 1)
        {
            ResetTimer();
        }

        //When there is enough players in the room begin the timer
        if (readyToStart)
        {
            fullGameTimer -= Time.deltaTime;
            timerToStartGame = fullGameTimer;
        }
        else if (readyToCountDown)
        {
            notFullGameTimer -= Time.deltaTime;
            timerToStartGame = notFullGameTimer;
        }

        //format and display countdown timer
        string tempTimer = string.Format("{0:00}", timerToStartGame);
        timerToStartDisplay.text = tempTimer;
        //if the countdown timer reaches 0 the game will begin
        if (timerToStartGame <= 0f)
        {
            if (startingGame)
                return;
            StartGame();
        }
    }

    void ResetTimer()
    {
        //resets the countdown timer
        timerToStartGame = maxWaitTime;
        notFullGameTimer = maxWaitTime;
        fullGameTimer = maxFullGameWaitTime;
    }
    
    void StartGame()
    {
        //multiplayer scene is loaded to begin the match
        startingGame = true;
        if (!PhotonNetwork.IsMasterClient)
            return;

        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }

    public void DelayCancel()
    {
        Debug.Log("In DelayCancel()");
        //public function paired to cancel button in waiting room scene
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(menuSceneIndex);
    }

}

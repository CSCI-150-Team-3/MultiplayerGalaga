using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton;//button used for creating and joining a game.
    [SerializeField]
    private GameObject quickCancelButton;//button used to stop searching for a game.
    [SerializeField]
    private int RoomSize;//Manual set the number of players allowed in a lobby at one time.

    public override void OnConnectedToMaster()//Callback function for when first connection is established
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }

    public void QuickStart()//Paired to quick start button
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();//First tries to join an existing room
        Debug.Log("Quick Start Activated");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)//callback function for when a room could not be joined
    {
        Debug.Log("Failed to join a room");
        CreateRoom();//create a new room for others to join
    }

    void CreateRoom()//Function to create a room for others to join
    {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000); //creating a random ID for the room
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };

        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);//attempting to create a new room
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)//callback function for when failing to create a lobby
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom();//Retrying to create a new room with a different id
    }

    public void QuickCancel()//paired with the cancel button to stop looking for a room
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();//leave the room
    }

}

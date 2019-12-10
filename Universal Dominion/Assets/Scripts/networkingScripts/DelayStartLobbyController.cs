using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DelayStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject delayStartButton;//button used for creating and joining a game
    //[SerializeField]
    //private GameObject delayCancelButton;//button used to stop searching for a game to join.
    [SerializeField]
    private int RoomSize = 2; //Manually set the number of players allowed in a room at once

    public override void OnConnectedToMaster()//Callback function for when the first connection is established
    {
        PhotonNetwork.AutomaticallySyncScene = true;//Makes it so whatever scene the master client is synced by everyone else
        delayStartButton.SetActive(true);
    }

    public void DelayStart()//paired to delay start button
    {
        delayStartButton.SetActive(false);
        //delayCancelButton.SetActive(true);

        PhotonNetwork.AuthValues = new Photon.Realtime.AuthenticationValues("Player" + Random.Range(0, 100));
        PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(0, 1000000);

        PhotonNetwork.JoinRandomRoom(null, 0);//first tries to join an existing room
        Debug.Log("Delay Start Called - " + PhotonNetwork.NickName);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("returnCode: " + returnCode);
        Debug.Log("Message: " + message);
        CreateRoom();//if joining a room failed then create one for others to join
    }

    void CreateRoom()//Function to create a room for others to join
    {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000); //creating a random ID for the room
        RoomOptions roomOps = new RoomOptions();// {IsOpen=true, MaxPlayers = (byte)RoomSize };
        roomOps.IsOpen = true;
        roomOps.IsVisible = true;
        roomOps.MaxPlayers = (byte)RoomSize;

        //place this in the following null to revert back ___ "Room" + randomRoomNumber ___
        //PhotonNetwork.CreateRoom(null, roomOps);//attempting to create a new room
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)//callback function for when failing to create a lobby
    {
        Debug.Log("Failed to create room... trying again");
        CreateRoom();//Retrying to create a new room with a different id
    }

    public void QuickCancel()//paired with the cancel button to stop looking for a room
    {
        //delayCancelButton.SetActive(false);
        delayStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();//leave the room
    }
}

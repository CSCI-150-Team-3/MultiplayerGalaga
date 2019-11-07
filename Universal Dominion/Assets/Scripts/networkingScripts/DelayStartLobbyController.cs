using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class DelayStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject delayStartButton;//button used for creating and joining a game
    [SerializeField]
    private GameObject delayCancelButton;//button used to stop searching for a game to join.
    [SerializeField]
    private int RoomSize; //Manually set the number of players allowed in a room at once

    public override void OnConnectedToMaster()//Callback function for when the first connection is established
    {
        PhotonNetwork.AutomaticallySyncScene = true;//Makes it so whatever scene the master client is synced by everyone else
        delayStartButton.SetActive(true);
    }

    public void DelayStart()//paired to delay start button
    {
        delayStartButton.SetActive(false);
        delayCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();//first tries to join an existing room
        Debug.Log("Delay Start Called");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        CreateRoom();//if joining a room failed then create one for others to join
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
        delayCancelButton.SetActive(false);
        delayStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();//leave the room
    }
}

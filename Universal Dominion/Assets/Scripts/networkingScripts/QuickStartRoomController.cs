using Photon.Pun;
using UnityEngine;

public class QuickStartRoomController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private int multiplayerSceneIndex; //Number for the build index to the multiplayer scene

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()//callback function for when we successfully join or create a room
    {
        Debug.Log("Joined a room");
        StartGame();
    }

    private void StartGame()//Function for loading into the multiplayer scene.
    {
        if(PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Starting Game");
            PhotonNetwork.LoadLevel(multiplayerSceneIndex);//because of autosyncscene all players who join are synced to master
        }
    }

}

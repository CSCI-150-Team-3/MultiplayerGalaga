using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to server..");
        PhotonNetwork.ConnectUsingSettings();
    }

    private void OnConnectedTomaster()
    {
        Debug.Log("Connected to master.");
        PhotonNetwork.NickName = PlayerNetwork.Instance.PlayerName;

        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    private void OnJoinedLobby()
    {
        Debug.Log("Joined lobby.");
    }

}

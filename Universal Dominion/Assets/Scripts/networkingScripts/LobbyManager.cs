using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class LobbyManager : NetworkLobbyManager
{

    public GameObject Lobby;

    public override void OnStartHost()
    {
        base.OnStartHost();
        print("A game was created!");
        Lobby.SetActive(true);
    }

}

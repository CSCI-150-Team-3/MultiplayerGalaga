using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;


public class LobbyMenu : MonoBehaviour
{

    public TMP_InputField LobbyNameInput;
    public LobbyManager lobbyManager;

    public void OnClickHostLobbyButton()
    {
        lobbyManager.StartMatchMaker();
        lobbyManager.matchMaker.CreateMatch(LobbyNameInput.text, (uint)lobbyManager.maxPlayers, true, "", "", "", 0, 0, lobbyManager.OnMatchCreate);
    }

}

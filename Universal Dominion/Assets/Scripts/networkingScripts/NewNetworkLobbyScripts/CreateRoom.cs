using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateRoom : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Text _roomName;

    private Text RoomName
    {
        get {return _roomName;}
    }

    public void OnClick_CreateRoom()
    {
        if(PhotonNetwork.CreateRoom(RoomName.text))
        {
            print("Create room successfully sent.");
        }else
        {
            print("Create room failed to send.");
        }
    }

    public void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("create room failed: " + codeAndMessage[1]);
    }

    public void OnCreatedRoom()
    {
        print("Room created successfully.");
    }

}

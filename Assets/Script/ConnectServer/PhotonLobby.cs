using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonLobby : MonoBehaviourPunCallbacks
{

    public static PhotonLobby lobby;
    public GameObject battleButton;
    public GameObject cancleButton;

    private void Awake()
    {
        lobby = this; //Creates the singleton, Lives withing the Main menu scene.
    }

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); //Connects to Master photon server.
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Player has connected to the Photon master server");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true); //Player is now connected to servers, enables battlebutton to allow join a game
        //base.OnConnectedToMaster(); 
    }

    public void OnBattleBottonClicked()
    {
        Debug.Log("Botton was Click");
        battleButton.SetActive(false);
        cancleButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to join a random game but failed. There must be no open games avaliable");
        CreateRoom();
        //base.OnJoinRoomFailed(returnCode, message);

    }

    void CreateRoom()
    {
        Debug.Log("Create room");
        int randomRoom = Random.Range(0, 10000);
        /*
        RoomOptions roomOps = new RoomOptions();
        roomOps.IsVisible = true;
        roomOps.IsOpen = true;
        roomOps.MaxPlayers = 10;
        */
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)MultiplayerSetting.multiplayerSetting.maxPlayer };

        PhotonNetwork.CreateRoom("Room" + randomRoom, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("We are now in room");
        //base.OnJoinedRoom();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Tried to create a newroom but failed, there must already be a room with the same name");
        CreateRoom();
        //base.OnCreateRoomFailed(returnCode, message);
    }

    public void OnCanclebuttonClick()
    {
        Debug.Log("Canclebutton was click");
        cancleButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}

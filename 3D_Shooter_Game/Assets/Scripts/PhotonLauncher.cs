using System.Collections;
using Photon.Pun;
using UnityEngine;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    public GameObject mainMenu, loading, roomMenu;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        loading.SetActive(false);
        mainMenu.SetActive(true);
        Debug.Log("OnJoinedLobby");
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        loading.SetActive(false);
        roomMenu.SetActive(true);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Failed to create room"+ message);
    }
}

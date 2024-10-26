using System.Collections;
using Photon.Pun;
using UnityEngine;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    public GameObject mainMenu, loading;
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
}

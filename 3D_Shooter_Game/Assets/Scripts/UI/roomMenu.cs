using Photon.Pun;
using UnityEngine;
using UnityEngine.UIElements;

public class roomMenu : MonoBehaviour
{

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        Label roomName = root.Q<Label>("roomName");
        roomName.text += ": "+ PhotonNetwork.CurrentRoom.Name;
    }

}

using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private Button _createRoomBtn;
    public GameObject createRoom;
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        _createRoomBtn = root.Q<Button>("CreateRoomBtn");
        _createRoomBtn.clicked += CreateRoomBtnOnClicked;
    }

    private void CreateRoomBtnOnClicked()
    {
        gameObject.SetActive(false);
        createRoom.SetActive(true);
    }
}

using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayStartLobby : MonoBehaviourPunCallbacks
{
    [SerializeField]
    public static DelayStartLobby lobby;
    [SerializeField]
    public GameObject battleButton;
    [SerializeField]
    public GameObject cancelButton;
    [SerializeField]
    public InputField nickname;

    [SerializeField]
    private int roomSize=2;
    private void Awake()
    {
        lobby = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PhotonNetwork.ConnectUsingSettings();// connect to mastet photon server
    }

    public override void OnConnectedToMaster()
    {
        // tells what region we are connected
        Debug.Log("We are now connected to the " + PhotonNetwork.CloudRegion + "");
        PhotonNetwork.AutomaticallySyncScene = true;
        battleButton.SetActive(true);
 

    }

    public void OnBattleButtonClicked()
    {
        setNickName();
        Debug.Log("Battle button was Clicked");
        battleButton.SetActive(false);
        cancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a random room makinga new room");
        createRoom();
    }


    void createRoom()
    {
        Debug.Log("Trying to Create room");
        int randomRoomName = Random.Range(0, 1000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomName, roomOps);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joine droom");
        base.OnJoinedRoom();

    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("already room with same name");
        createRoom();
    }

    public void OnCancelButtonClicked()
    {
        cancelButton.SetActive(false);
        battleButton.SetActive(true);
        PhotonNetwork.Disconnect();
    }
    // Update is called once per frame

    void setNickName()
    {
  
        PhotonNetwork.LocalPlayer.NickName= nickname.text.ToString();
        Debug.Log(PhotonNetwork.LocalPlayer.NickName);
    }
    void Update()
    {

    }
}

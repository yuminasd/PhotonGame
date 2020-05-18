using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class DelayStartWaitingRoom : MonoBehaviourPunCallbacks
{

    private PhotonView PV;

    [SerializeField]
    public int multiplayerSceneIndex;

    [SerializeField]
    public int menuSceneIndex;

    private int playerCount;
    private int roomSize;

    [SerializeField]
    public int minPlayersToStart;

    [SerializeField]
    public Text timerToStartDisplay;
    [SerializeField]
    public Text roomCountDisplay;

    //bool values for if the timer can count down;
    private bool readyToStart;
    private bool startingGame;


    [SerializeField]
    public float maxWaitTime;
    private float timer;

   
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        timer = maxWaitTime;

        PlayerCountUpdate();
    }

    void PlayerCountUpdate()
    {
        playerCount = PhotonNetwork.PlayerList.Length;
        roomSize = PhotonNetwork.CurrentRoom.MaxPlayers;
        roomCountDisplay.text = "Players: " + playerCount + "/ " + roomSize;

        if(playerCount == roomSize)
        {
            readyToStart = true;
        }
        else
        {
            readyToStart = false;
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer )
    {
        PlayerCountUpdate();

        if (PhotonNetwork.IsMasterClient)
        {
            PV.RPC("RPC_SendTimer", RpcTarget.Others, timer);
        }
    }
    [PunRPC]
    private void RPC_SendTimer(float timeIn)
    {
        timer = timeIn;
    }


    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        // base.OnPlayerLeftRoom(otherPlayer);
        PlayerCountUpdate();
    }
    // Update is called once per frame
    void Update()
    {
        WaitingForMorePlayers();
    }

    void WaitingForMorePlayers()
    {
        if (playerCount <=1 )
        {
            ResetTimer();
        }

        if(readyToStart)
        {
            timer -= Time.deltaTime;
        }

       // string tempTimer = string.Format("0:00", timerToStartGame);
        timerToStartDisplay.text = timer.ToString();

        if(timer <= 0f)
        {
            if (startingGame)
            {
                return;
            }
            StartGame();
        }
    }

    void ResetTimer()
    {
        timer = maxWaitTime;
    }

    public void StartGame()
    {
        startingGame = true;

        if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }
        PhotonNetwork.CurrentRoom.IsOpen = false;
        PhotonNetwork.LoadLevel(multiplayerSceneIndex);
    }

    public void DelayLeave()
    {
        PhotonNetwork.Disconnect();
        UnityEngine.SceneManagement.SceneManager.LoadScene(menuSceneIndex);
    }
}

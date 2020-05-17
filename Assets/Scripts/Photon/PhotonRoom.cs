using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

//inheritanceis after :
public class PhotonRoom : MonoBehaviourPunCallbacks, IInRoomCallbacks
{
    //Room info
    public static PhotonRoom room;
    private PhotonView PV;

    // public bool isGameLoaded;
    public int currectScene;
    public int multiplayerScene;

    /*
    // Player info
    Player[] photonPlayers;

    public int playersInRoom;
    public int myNumberInRoom;
    public int playersInGame;
    */

    private void Awake()
    {
        if (PhotonRoom.room == null)
        {
            PhotonRoom.room = this;
        }
        else
        {
            if (PhotonRoom.room != this)
            {
                UnityEngine.Object.Destroy(PhotonRoom.room.gameObject); //if equals different instance destroy old instance
                PhotonRoom.room = this;
            }
        }
        DontDestroyOnLoad(this.gameObject);// this game object will be alive in next scene
    
    }

    void Start()
    {
          PV = GetComponent<PhotonView>();// don't want to have to instance of photon view objects
    }

    public override void OnEnable()
    {
        //subscribe to functions
        base.OnEnable();
        PhotonNetwork.AddCallbackTarget(this);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }
    public override void OnDisable()
    {
        base.OnDisable();
        PhotonNetwork.RemoveCallbackTarget(this);
        SceneManager.sceneLoaded -= OnSceneFinishedLoading;
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("now Inside a room");

        StartGame();
        /* photonPlayers = PhotonNetwork.PlayerList;
          playersInRoom = photonPlayers.Length;
         myNumberInRoom = playersInRoom;
         PhotonNetwork.NickName = myNumberInRoom.ToString();
         */
    }

    void StartGame()
    {
         if (!PhotonNetwork.IsMasterClient)
            return;
        Debug.Log("Loading Level");
        PhotonNetwork.LoadLevel(multiplayerScene);
    }

    void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        currectScene = scene.buildIndex;// when the scene is loaded
        if (currectScene == multiplayerScene)
        {
            /*
             * isGameLoaded = true;
             *if(MultiplayerSetting.multiplayerSetting.delayStart)
             * {
             *      PV.RPC("RPC_LoadedGameScene", RpcTarget.MasterClient);
             * }
             * else
             */
            {
                CreatePlayer();
            }

        }
    }

    private void CreatePlayer()
    {
        //creates player network controller but not a player character
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + "has left the game");
        base.OnPlayerLeftRoom(otherPlayer);
       // playersInRooom--; //use this to disp0lay the next screen
    }
}

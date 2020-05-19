using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayGameSetup : MonoBehaviour
{
    public static DelayGameSetup GS;
    public GameObject[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void CreatePlayer()
    {
        Debug.Log("CreatingPlayer");
        //creates player network controller but not a player character
       GameObject myPlayer = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Capsule"), spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].transform.position, spawnPoints[PhotonNetwork.LocalPlayer.ActorNumber - 1].transform.rotation, 0);
        myPlayer.transform.Find("Camera").gameObject.SetActive(true);
        ((MonoBehaviour)myPlayer.GetComponent("FPSControl")).enabled = true;
        myPlayer.transform.Find("Body_Mesh").gameObject.SetActive(false);
        myPlayer.transform.Find("Bip001").gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (DelayGameSetup.GS == null)
        {
            DelayGameSetup.GS = this;
        }

    }

    public void DisconnectPlayer()
    {
        StartCoroutine(DisconnectAndLoad());
    }

    IEnumerator DisconnectAndLoad()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
        {
            yield return null;
        }

        SceneManager.LoadScene(0);
    }


}

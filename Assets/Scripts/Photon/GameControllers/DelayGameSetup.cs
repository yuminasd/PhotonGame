using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayGameSetup : MonoBehaviour
{
    public static DelayGameSetup GS;
    public Transform spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer();
        
    }

    public void CreatePlayer()
    {
        Debug.Log("CreatingPlayer");
        //creates player network controller but not a player character
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PhotonNetworkPlayer"), transform.position, Quaternion.identity, 0);
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

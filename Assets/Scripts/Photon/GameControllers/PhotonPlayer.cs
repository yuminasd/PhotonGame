using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    public PhotonView PV;
    public GameObject myAvatar;
    public int myTeam=1;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();

        if (PV.IsMine)
        {
            //   myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "FirstPerson-AIO"),
            //    DelayGameSetup.GS.spawnPoints[spawnPicker].position, DelayGameSetup.GS.spawnPoints[spawnPicker].rotation, 0);
            myAvatar = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerAvatar"),
         DelayGameSetup.GS.spawnPoints.position, DelayGameSetup.GS.spawnPoints.rotation, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
     
    }

}

using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Checker : MonoBehaviour
{

    public PhotonView PV;
    public bool eyeball;
    public bool spacer;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if ( eyeball&&spacer)
        {
            PV.RPC("openHole", RpcTarget.All);
        }
    }

    [PunRPC]
    void openHole()
    {
        GetComponent<Collider>().enabled = false;
    }
}

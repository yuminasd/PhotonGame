using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class winScene : MonoBehaviour
{
   // public PhotonView PV;
    private float timer;
    private bool okay;
    // Start is called before the first frame update
    void Start()
    {

        timer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <0&&!okay)
        {
            okay = true;
            PhotonNetwork.LoadLevel(4);

        }
    
    }
}



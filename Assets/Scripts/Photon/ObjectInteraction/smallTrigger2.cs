using System.Collections;
using System.Collections.Generic;

using Photon.Pun;
using UnityEngine;

public class smallTrigger2 : MonoBehaviour
{
    public GameObject door2;
    public GameObject spawn2;
    public PhotonView PV;
    private bool enter = false;
    void Start()
    {
        PV.GetComponent<PhotonView>();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(" trigger2 is set");
        if (other.gameObject.CompareTag("Player"))
        {
            // Vector3 bb = spawn2.transform.position;

            other.gameObject.transform.position = spawn2.transform.position;
            spawn2.transform.position = other.transform.position;
         //   teleportPlayer(other.name,bb.x.ToString(),bb.y.ToString(),bb.z.ToString());
            PV.RPC("Enter", RpcTarget.All, null);
        }
        //parentScript.recieveTriggerEnter (name, other);
    }

    [PunRPC]
    void Enter()
    {
        door2.SetActive(true);
    }

    //[PunRPC] 
    //void teleportPlayer(string name, string x, string y, string z)
    //{ GameObject player = GameObject.Find(name); 
    //    if (player != null) { 
    //        player.transform.position = new Vector3(float.Parse(x), float.Parse(y), float.Parse(z)); 
    //    } 
    //}

}

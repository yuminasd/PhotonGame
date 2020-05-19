using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class Move : MonoBehaviour
{
    public PhotonView PV;
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }


    [PunRPC]
   public void move(string direction)
    {
        Debug.Log("Ok");
        Vector3 shot = floor.transform.position;
        if (direction.Contains("Left"))
         {
         //   floor.GetComponent<iMove>().move(direction);
            floor.GetComponent<PhotonView>().RPC("move", RpcTarget.All, direction);
         }
        if (direction.Contains("Right"))
         {
            //  floor.GetComponent<iMove>().move(direction);
            floor.GetComponent<PhotonView>().RPC("move", RpcTarget.All, direction);
        }
        if (direction.Contains("Forward"))
         {
            //   floor.GetComponent<iMove>().move(direction);
            floor.GetComponent<PhotonView>().RPC("move", RpcTarget.All, direction);
        }
        if (direction.Contains("Backward"))
        {
            //  floor.GetComponent<iMove>().move(direction);
            floor.GetComponent<PhotonView>().RPC("move", RpcTarget.All, direction);
        }
        if (direction.Contains("Up"))
        {
            //  floor.GetComponent<iMove>().move(direction);
            floor.GetComponent<PhotonView>().RPC("move", RpcTarget.All, direction);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

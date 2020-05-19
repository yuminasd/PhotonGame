using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;

public class TouchDaddy : MonoBehaviour
{

    private PhotonView PV;
    public Transform rayorigin;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        // if(!PV.IsMine)
        // {
        //      return;
        //   }
        if (PV.IsMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PV.RPC("moveCircle", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void moveCircle()
    {
        RaycastHit hit;
     

            if (Physics.Raycast(rayorigin.position, rayorigin.TransformDirection(Vector3.forward), out hit, 1000f))
            {
            Debug.Log("shooting the goo"+hit.transform.name);

                if(hit.transform.tag.Contains("Left")|| hit.transform.tag.Contains("Right") || hit.transform.tag.Contains("Forward") || hit.transform.tag.Contains("Backward") || hit.transform.tag.Contains("Up"))
                {
                Debug.Log(hit.transform.tag);
                hit.transform.GetComponent<Move>().move(hit.transform.tag);
                }
            }
            else
            {
                Debug.Log("miss dab");
            }
    }
}

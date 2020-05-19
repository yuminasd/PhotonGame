using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class iMove : MonoBehaviour
{
  public  PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
      PV=  PV.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    [PunRPC]
    public void move(string direction)
    {
        if ( direction.Contains("Left"))
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (direction.Contains("Rightt"))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (direction.Contains("Forward"))
        {
            transform.Translate(0, 0.1f, 0);
        }
        if (direction.Contains("Backward"))
        {
            transform.Translate(0.1f, -0.1f, 0);
        }
        if (direction.Contains("Up"))
        {
            transform.Translate(0, 0, 0.1f);
        }
    }
}

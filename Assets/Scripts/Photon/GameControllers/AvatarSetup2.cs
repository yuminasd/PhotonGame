using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;


public class AvatarSetup2 : MonoBehaviour
{

    public int playerHealth;
    public int playerDamage;
    private PhotonView PV;
    public GameObject myCharacter;
    public int characterValue;

    public Camera cameras;
    public AudioListener listen;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if (PV.IsMine)
        {
            PV.RPC("RPC_AddCharacter", RpcTarget.AllBuffered, PlayerInfo.PI.mySelectedCharacter);
        }
        else
        {
            Destroy(cameras);
            Destroy(listen);
        }
    }

    [PunRPC]
    void RPC_AddCharacter(int whichCharacter)
    {
        characterValue = whichCharacter;
        myCharacter = Instantiate(PlayerInfo.PI.allCharacters[whichCharacter], transform.position, transform.rotation, transform);
    }
}

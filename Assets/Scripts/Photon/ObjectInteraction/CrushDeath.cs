using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushDeath : MonoBehaviour
{
    public PhotonView PV;
    public GameObject hole;
    private bool open=false;
    // Start is called before the first frame update
    void Start()
    {
        PV.GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime, Space.Self);
        if (transform.position.y < 2.6 && !open )
        {
            Debug.Log("Open Sesame babe");
            open = true;
            hole.GetComponent<Collider>().enabled = false;
        }
    }

   void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player"))
        {

        if(!PhotonNetwork.IsMasterClient)
        {
            return;
        }

        PhotonNetwork.LoadLevel(3);

        }
    }
}
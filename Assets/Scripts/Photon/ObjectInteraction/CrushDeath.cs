using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushDeath : MonoBehaviour
{
    public PhotonView PV;
    public GameObject[] hole;
    private bool isn = false;
    // Start is called before the first frame update
    void Start()
    {
      PV=  PV.GetComponent<PhotonView>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime, Space.Self);
        if (transform.position.y < 5&&isn !=true)
        {
            isn = true;
            Debug.Log("Open Sesame babe");
            for (int i = 0; i < hole.Length; i++)
            {
                hole[i].GetComponent<Checker>().spacer = true;
            }
 
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Player"))
        {
        PhotonNetwork.LoadLevel(3);

        }
    }
}
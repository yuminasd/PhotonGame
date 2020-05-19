using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrushDeath : MonoBehaviour
{
    public PhotonView PV;
<<<<<<< HEAD
    public GameObject hole;
<<<<<<< HEAD
=======
    public GameObject[] hole;
>>>>>>> 4e4f69bdf180ee11151ee949e4a333d87ffc186b
    private bool isn = false;
=======
    private bool open=false;
>>>>>>> parent of 75d814c... Nothing happened
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
<<<<<<< HEAD
<<<<<<< HEAD
            hole.GetComponent<Checker>().spacer = true;
=======
            for (int i = 0; i < hole.Length; i++)
            {
                hole[i].GetComponent<Checker>().spacer = true;
            }
>>>>>>> 4e4f69bdf180ee11151ee949e4a333d87ffc186b
 
=======
            open = true;
            hole.GetComponent<Collider>().enabled = false;
>>>>>>> parent of 75d814c... Nothing happened
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
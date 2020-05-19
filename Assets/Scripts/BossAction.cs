using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class BossAction : MonoBehaviour
{
    public GameObject imagination;
    public GameObject[] spawn;
    public PhotonView PV;
    private float timer;
    //when the other person enters the trigger a timer is created, then it displays the win page
    // Start is called before the first frame update
    void Start()
    {
        PV = PV.GetComponent<PhotonView>();
        timer = 1f;  
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if ( timer <= 0)
        {
            timer = 1f;
            transform.position = spawn[Random.Range(0, spawn.Length)].transform.position;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //imagination.SetActive(true);
        if (other.gameObject.CompareTag("Player"))
        {
            PhotonNetwork.LoadLevel(4);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2WinScene : MonoBehaviour
{
    public GameObject imagination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            imagination.SetActive(true);
            //    PhotonNetwork.LoadLevel(4);
        }
    }
}

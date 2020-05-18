using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour
{
    public GameObject cylinder;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseEnter()
    {
        Debug.Log("Hi mom");
        cylinder.GetComponent<Checker>().eyeball = true;
    }

    private void OnMouseExit()
    {
        Debug.Log("Bye mom");
        cylinder.GetComponent<Checker>().eyeball = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

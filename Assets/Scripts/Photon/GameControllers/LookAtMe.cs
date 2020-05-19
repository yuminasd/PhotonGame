using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour
{
<<<<<<< HEAD
    public GameObject cylinder;
=======
    public GameObject[] cylinder;
>>>>>>> 4e4f69bdf180ee11151ee949e4a333d87ffc186b
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnMouseEnter()
    {
        Debug.Log("Hi mom");
<<<<<<< HEAD
        cylinder.GetComponent<Checker>().eyeball = true;
=======
        for (int i = 0; i < cylinder.Length; i++)
        {
            cylinder[i].GetComponent<Checker>().eyeball = true;
        }
>>>>>>> 4e4f69bdf180ee11151ee949e4a333d87ffc186b
    }

    private void OnMouseExit()
    {
        Debug.Log("Bye mom");
<<<<<<< HEAD
        cylinder.GetComponent<Checker>().eyeball = false;
=======
        for (int i = 0; i < cylinder.Length; i++)
        {
            cylinder[i].GetComponent<Checker>().eyeball = false;
        }
>>>>>>> 4e4f69bdf180ee11151ee949e4a333d87ffc186b
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

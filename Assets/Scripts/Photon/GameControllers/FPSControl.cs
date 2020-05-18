using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class FPSControl : MonoBehaviour
{

    [SerializeField]
    private PhotonView PV;
    public GameObject cam;
    public float speed = 2f, sensitivity = 2f, jumpDistance = 5f;
    float moveFB, moveLR, rotX, rotY, verticalVelocity;
    CharacterController charCon;


    // Start is called before the first frame update
    void Start()
    {
      PV= PV.GetComponent<PhotonView>();
        if (!PV.IsMine)
        {
            return;
        }

        PV.RPC("disableCursor", RpcTarget.All, null);
        
        charCon = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }
        moveFB = Input.GetAxis("Vertical") * speed;
        moveLR = Input.GetAxis("Horizontal") * speed;

        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotY = Mathf.Clamp(rotY,-60f,60);

        Vector3 movement = new Vector3(moveLR, verticalVelocity, moveFB);
        transform.Rotate(0, rotX, 0);
        cam.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        movement = transform.rotation * movement;
        charCon.Move(movement * Time.deltaTime);

        if (charCon.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                verticalVelocity = jumpDistance;
            }
        }
    }


    private void FixedUpdate()
    {
        if(!charCon.isGrounded)
        {
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }
    }

    [PunRPC]
    void disableCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

}

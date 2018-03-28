﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseLook : NetworkBehaviour
{

    //public Transform playerBody;
    public float mouseSensitivity = 7.0f;

    float xAxisClamp = 0.0f;

    public float nextJump = 0.5F;
    public float jumpDelta = 0.5F;
    public float myTime = 0.0F;
    public Transform cue;


    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Use this for initialization
    void Start()
    {
        mouseSensitivity = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {

        RotateCamera();
        Shoot();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float rotAmountX = mouseX * mouseSensitivity;
        float rotAmountY = mouseY * mouseSensitivity;

        xAxisClamp -= rotAmountY;

        Vector3 targetRotCam = transform.rotation.eulerAngles;
        //Vector3 targetRotBody = playerBody.rotation.eulerAngles;

        targetRotCam.x -= rotAmountY;
        targetRotCam.y += rotAmountX;
        targetRotCam.z = 0;
        //targetRotBody.y += rotAmountX;

        if (xAxisClamp > 80)
        {
            xAxisClamp = 80;
            targetRotCam.x = 80;
        }
        else if (xAxisClamp < -80)
        {
            xAxisClamp = -80;
            targetRotCam.x = 270;
        }



        transform.rotation = Quaternion.Euler(targetRotCam);
        //playerBody.rotation = Quaternion.Euler(targetRotBody);


    }


    void Shoot()// change player view between viewmodes
    {

        myTime = myTime + Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > nextJump)
        {
            nextJump = myTime + jumpDelta;

            cue.transform.Translate(-Vector3.forward * Time.deltaTime);

            //cue.transform.Translate(Vector3.forward * Time.deltaTime);

            nextJump = nextJump - myTime;
            myTime = 0.0F;
        }
    }
}

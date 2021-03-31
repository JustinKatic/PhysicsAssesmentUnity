﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamLook : MonoBehaviour
{
    public float lookSensitivity;
    public float minXlook;
    public float maxXlook;
    public Transform camAnchor;

    public bool invertXrotation;

    private float curXRot;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        //get mouse x and y input
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        //rotate the player horizontally
        transform.eulerAngles += Vector3.up * x * lookSensitivity;

        if (invertXrotation)
            curXRot += y * lookSensitivity;
        else
            curXRot -= y * lookSensitivity;


        curXRot = Mathf.Clamp(curXRot, minXlook, maxXlook);

        Vector3 clampedAngle = camAnchor.eulerAngles;
        clampedAngle.x = curXRot;

        camAnchor.eulerAngles = clampedAngle;



    }

}
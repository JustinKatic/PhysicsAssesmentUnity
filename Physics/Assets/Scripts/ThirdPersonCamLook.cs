/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: Cam look script causes the cam to look in direction mouse is moving and causes the transform
 *to look in same direction as cam
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamLook : MonoBehaviour
{
    public float m_lookSensitivity;
    public float m_minXlook;
    public float m_maxXlook;
    public Transform m_camAnchor;

    public bool m_invertXrotation;

    private float m_curXRot;


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
        transform.eulerAngles += Vector3.up * x * m_lookSensitivity;

        if (m_invertXrotation)
            m_curXRot += y * m_lookSensitivity;
        else
            m_curXRot -= y * m_lookSensitivity;


        m_curXRot = Mathf.Clamp(m_curXRot, m_minXlook, m_maxXlook);

        Vector3 clampedAngle = m_camAnchor.eulerAngles;
        clampedAngle.x = m_curXRot;

        m_camAnchor.eulerAngles = clampedAngle;



    }

}

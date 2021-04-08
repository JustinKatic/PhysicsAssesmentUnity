/************************************************************************************************************************
 *Name: Justin Katic  
 *Date Created: Thurs April 1 2021
 *Description: causes ui elements to look towards the cam so we can always see sprite front on.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBillBoard : MonoBehaviour
{
    Transform m_cam;

    void Awake()
    {
        m_cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }


    void LateUpdate()
    {
        transform.LookAt(transform.position + m_cam.forward);
    }
}

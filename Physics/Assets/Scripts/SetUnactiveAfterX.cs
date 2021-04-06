/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: Sets object to go unactive after x seconds
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUnactiveAfterX : MonoBehaviour
{
    [SerializeField] float m_setSelfUnactiveAfterX;

    private void OnEnable()
    {
        Invoke("SetUnActive", m_setSelfUnactiveAfterX);

    }
    void SetUnActive()
    {
        gameObject.SetActive(false);
    }
}

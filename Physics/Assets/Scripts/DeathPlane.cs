/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: if player hits trigger raise death event to any event listeners in scene.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public GameEvent m_deathEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            m_deathEvent.Raise();
    }
}

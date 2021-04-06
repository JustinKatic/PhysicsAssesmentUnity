/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: causes the object to turn its joints into a ragdoll effect.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    private Animator m_anim = null;
    public List<Rigidbody> m_rigidbodies = new List<Rigidbody>();

    public bool ragdollOn
    {
        get { return !m_anim.enabled; }
        set
        {
            m_anim.enabled = !value;
            foreach(Rigidbody r in m_rigidbodies)
            {
                r.isKinematic = !value;
            }
        }
    }
    void Start()
    {
        m_anim = GetComponent<Animator>();
        foreach (Rigidbody r in m_rigidbodies)
        {
            r.isKinematic = true;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ragdoll : MonoBehaviour
{
    private Animator anim = null;
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    public bool ragdollOn
    {
        get { return !anim.enabled; }
        set
        {
            anim.enabled = !value;
            foreach(Rigidbody r in rigidbodies)
            {
                r.isKinematic = !value;
            }
        }
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        foreach (Rigidbody r in rigidbodies)
        {
            r.isKinematic = true;
        }

    }

}

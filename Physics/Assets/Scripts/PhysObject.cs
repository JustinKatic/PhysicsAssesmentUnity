using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysObject : MonoBehaviour
{
    public Material awakeMat = null;
    public Material sleepingMat = null;

    private Rigidbody rb = null;

    private bool wasAsleep = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.IsSleeping() && !wasAsleep && sleepingMat != null)
        {
            wasAsleep = true;
            GetComponent<MeshRenderer>().material = sleepingMat;
        }
        if(!rb.IsSleeping() && wasAsleep && awakeMat != null)
        {
            wasAsleep = false;
            GetComponent<MeshRenderer>().material = awakeMat;
        }
    }
}

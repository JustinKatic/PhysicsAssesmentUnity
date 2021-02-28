using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjectsInChildNonKin : MonoBehaviour
{
    public void SetObjNonKin()
    {
        Rigidbody[] rbs = gameObject.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < rbs.Length; i++)
        {
            rbs[i].isKinematic = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Triggers : UnityEvent { };
public class OnPlayerTriggers : MonoBehaviour
{

    public string tagOfObjThatCanEnter;
    public Triggers onTriggerEnter;
    public Triggers onTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagOfObjThatCanEnter))
        {
            onTriggerEnter.Invoke();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagOfObjThatCanEnter))
        {
            onTriggerExit.Invoke();
        }
    }
}
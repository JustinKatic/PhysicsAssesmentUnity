using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEventTrueOnEnter : MonoBehaviour
{
    public GameEvent MyEvent;

    private void OnTriggerEnter(Collider other)
    {
        MyEvent.Raise();
    }
}

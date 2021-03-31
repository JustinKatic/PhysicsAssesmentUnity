using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUnactiveAfterX : MonoBehaviour
{
    [SerializeField] float setSelfUnactiveAfterX;

    private void OnEnable()
    {
        Invoke("SetUnActive", setSelfUnactiveAfterX);

    }
    void SetUnActive()
    {
        gameObject.SetActive(false);
    }
}

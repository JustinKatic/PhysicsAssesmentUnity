using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnOff : MonoBehaviour
{
    public void ToggleObj(GameObject objToToggle)
    {
        objToToggle.SetActive(!objToToggle.activeSelf);
    }
}

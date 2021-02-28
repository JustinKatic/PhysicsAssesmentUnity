using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public void DisplayText(GameObject txtToDisplay)
    {
        txtToDisplay.SetActive(true);       
    }

    public void DisableText(GameObject txtToDisplay)
    {
        txtToDisplay.SetActive(false);
    }
}

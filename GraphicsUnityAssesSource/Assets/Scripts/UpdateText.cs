/************************************************************************************************************************
 *Name: Justin Katic 
 *Date Created: Thurs April 1 2021
 *Description: Updates text field in ui to given param
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_textToUpdate;
    [SerializeField] FloatVariable m_floatNeedingUpdated;

    private void Start()
    {
        UpdateTextVar(m_floatNeedingUpdated);
    }

    public void UpdateTextVar(FloatVariable floatVariable)
    {
        m_textToUpdate.text = floatVariable.RuntimeValue.ToString();
    }
}

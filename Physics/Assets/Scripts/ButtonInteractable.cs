/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: Button behaviours in game gui. functions that can be used with event system. 
 *-changes if button is interactable or not based on button cost.
 *-updated curreny values when button clicked.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonInteractable : MonoBehaviour
{
    public FloatVariable m_currency;
    public GameEvent m_updateCurrency;

    public GameObject m_snowButtonObj;
    public GameObject m_invisButtonObj;

    public float m_snowButtonCost;
    public float m_invisButtonCost;

    Button m_snowButton;
    Button m_invisButton;



    private void Start()
    {
        m_snowButton = m_snowButtonObj.GetComponent<Button>();
        m_invisButton = m_invisButtonObj.GetComponent<Button>();
        UpdateButtonInteractable();
    }

    public void SnowBuy()
    {
        m_currency.RuntimeValue -= m_snowButtonCost;
        m_updateCurrency.Raise();
    }
    public void InvisBuy()
    {
        m_currency.RuntimeValue -= m_invisButtonCost;
        m_updateCurrency.Raise();
    }

    public void UpdateButtonInteractable()
    {
        //SNOW BUTTON INTERACTABLE
        if (m_currency.RuntimeValue >= m_snowButtonCost)
        {
            m_snowButton.interactable = true;
        }
        else
        {
            m_snowButton.interactable = false;
        }

        //INVIS BUTTON INTERACTABLE
        if (m_currency.RuntimeValue >= m_invisButtonCost)
        {
            m_invisButton.interactable = true;
        }
        else
        {
            m_invisButton.interactable = false;
        }
    }

}

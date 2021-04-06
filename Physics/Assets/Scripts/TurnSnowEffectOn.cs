/************************************************************************************************************************
 *Name: Justin Katic  
 *public function call that turns snow effect on and then disables it after duration var
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSnowEffectOn : MonoBehaviour
{
    public BoolVariable m_snowEffectActive;
    public float m_duration;
    public GameObject m_effectToTurnOn;

    public void ActivateEffect()
    {
        m_effectToTurnOn.SetActive(true);
        m_snowEffectActive.RuntimeValue = true;
        Invoke("DisableSnow", m_duration);
    }
    public void DisableSnow()
    {
        m_effectToTurnOn.SetActive(false);
        m_snowEffectActive.RuntimeValue = false;
    }

}

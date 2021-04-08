/************************************************************************************************************************
 *Name: Justin Katic  
 *Date Created: Thurs April 1 2021
 *Description: public functions for anyone using a health bar to be able to update the health bar slider values.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider m_slider;

    public Gradient m_gradient;
    public Image m_fill;


    public void SetMaxHealth(float health)
    {
        m_slider.maxValue = health;
        m_slider.value = health;

        m_fill.color = m_gradient.Evaluate(1f);
    }

    public void SetHealth(float health)
    {
        m_slider.value = health;
        m_fill.color = m_gradient.Evaluate(m_slider.normalizedValue);
    }
}

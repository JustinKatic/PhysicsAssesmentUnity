/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: used to reset level
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public FloatVariable m_currency;
    public GameEvent m_updatecurrency;

    public void Resetlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        m_currency.RuntimeValue = 0;
        m_updatecurrency.Raise();
    }
}

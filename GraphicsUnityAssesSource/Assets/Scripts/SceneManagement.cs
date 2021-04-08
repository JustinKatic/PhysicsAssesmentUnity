/************************************************************************************************************************
 *Name: Justin Katic
 *Date Created: Thurs April 1 2021
 *Description: used to reset level and handle pausing game.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public FloatVariable m_currency;
    public FloatVariable numberOfActiveEnemies;

    public IntVariable m_nextWaveNum;

    public GameEvent m_updatecurrency;

    public BoolVariable invisActive;
    public BoolVariable snowActive;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (Input.GetKeyDown(KeyCode.R))
            Resetlevel();
    }

    public void Resetlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        m_nextWaveNum.RuntimeValue = 0;
        m_currency.RuntimeValue = 0;
        numberOfActiveEnemies.RuntimeValue = numberOfActiveEnemies.Value;
        m_updatecurrency.Raise();
        ResumeGame();
        invisActive.RuntimeValue = false;
        snowActive.RuntimeValue = false;

    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}

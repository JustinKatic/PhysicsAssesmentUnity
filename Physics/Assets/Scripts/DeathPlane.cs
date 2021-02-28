using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    public void Resetlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

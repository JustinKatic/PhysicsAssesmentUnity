using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Resetlevel();
    }
    public void Resetlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

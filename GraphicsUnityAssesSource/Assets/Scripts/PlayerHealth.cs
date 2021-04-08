/************************************************************************************************************************
 *Name: Justin Katic  
 *Date Created: Thurs April 1 2021
 *Description: handles Player health such as what happens when takes damage and what happens when enemy dies.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private float m_currentHealth;

    [SerializeField] private HealthBar m_healthBar;
    [SerializeField] float m_myMaxHealth;
    [SerializeField] bool m_iHaveAHealthBar;

    [SerializeField] ScriptableSoundObj m_DeathSound;
    [SerializeField] GameObject m_deathParticle;

    [SerializeField] Transform m_floatingTextSpawnPos;

    [SerializeField] GameEvent m_playerDead;


    // Start is called before the first frame update
    private void OnEnable()
    {
        m_currentHealth = m_myMaxHealth;
        if (m_iHaveAHealthBar)
            m_healthBar.SetMaxHealth(m_myMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Hurt(float _damage)
    {
        m_currentHealth -= _damage;
        FloatingTxt(_damage, m_floatingTextSpawnPos, "-", Color.red);
        if (m_iHaveAHealthBar)
            m_healthBar.SetHealth(m_currentHealth);

        if (m_currentHealth <= 0)
            Death();
    }

    public void Death()
    {
        m_playerDead.Raise();
        if (m_DeathSound)
            m_DeathSound.Play();
        else
            Debug.Log("no death sound added" + gameObject.name);

        InstantiateDeathParticle(m_deathParticle);

    }

    public void InstantiateDeathParticle(GameObject deathParticle)
    {
        if (deathParticle)
            Instantiate(deathParticle, transform.position, transform.rotation);
        else
            Debug.Log("no deathParticle Obj added" + gameObject.name);
    }

    public void FloatingTxt(float damage, Transform transformToSpawnTxtAt, string type, Color32 color)
    {
        GameObject points = ObjectPooler.m_sharedInstance.GetPooledObject("FloatingTxt");
        points.transform.position = transformToSpawnTxtAt.position;
        points.transform.rotation = Quaternion.identity;
        TextMeshPro txt = points.transform.GetChild(0).GetComponent<TextMeshPro>();
        txt.text = type + damage.ToString();
        txt.color = color;
        points.SetActive(true);
    }


}

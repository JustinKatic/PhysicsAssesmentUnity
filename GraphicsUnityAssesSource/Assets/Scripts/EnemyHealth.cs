/************************************************************************************************************************
 *Name: Justin Katic  
 *Date Created: Thurs April 1 2021
 *Description: handles enemies health such as what happens when takes damage and what happens when enemy dies.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    private float m_currentHealth;

    [SerializeField] Transform m_floatingTxtSpawn;

    [SerializeField] private HealthBar m_healthBar;
    [SerializeField] float m_myMaxHealth;
    [SerializeField] bool m_iHaveAHealthBar;

    [SerializeField] FloatVariable m_numberOfActiveEnemies;
    [SerializeField] GameObject m_hitVFX;
    [SerializeField] GameObject m_hitVFXSpawnPoint;

    [SerializeField] float m_currencyWorth;
    [SerializeField] FloatVariable m_currency;
    [SerializeField] GameEvent m_updateCurrency;

    DissolveEffect m_dissolveEffect;

    public bool m_isAlive = true;


    private void Awake()
    {
        m_dissolveEffect = gameObject.GetComponent<DissolveEffect>();
    }

    private void OnEnable()
    {
        m_currentHealth = m_myMaxHealth;
        if (m_iHaveAHealthBar)
            m_healthBar.SetMaxHealth(m_myMaxHealth);
    }

    public void TakeDamage(int _damageAmount)
    {
        if (m_isAlive)
        {
            m_currentHealth -= _damageAmount;

            GameObject hitVFX = ObjectPooler.m_sharedInstance.GetPooledObject("Blood");
            hitVFX.transform.position = m_hitVFXSpawnPoint.transform.position;
            hitVFX.SetActive(true);

            FloatingTxt(_damageAmount, m_floatingTxtSpawn, "-", Color.red);


            if (m_iHaveAHealthBar)
                m_healthBar.SetHealth(m_currentHealth);

            if (m_currentHealth <= 0)
                Die();
        }
    }

    private void Die()
    {
        m_isAlive = false;
        m_healthBar.gameObject.SetActive(false);
        m_numberOfActiveEnemies.RuntimeValue -= 1;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        Ragdoll(true);
        m_currency.RuntimeValue += m_currencyWorth;
        m_updateCurrency.Raise();
        m_dissolveEffect.m_dissolve = true;
        Invoke("DestroyEnemy", 3f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void Ragdoll(bool ToggleRagdol)
    {
        Ragdoll r = gameObject.GetComponentInParent<Ragdoll>();
        if (r != null)
        {
            r.ragdollOn = ToggleRagdol;
        }
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

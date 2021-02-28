using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 1;
    public int currentHealth;

    private void Start()
    {
        currentHealth = startingHealth;
    }
    private void OnEnable()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        Ragdoll();
        Invoke("DestroyEnemy", 4f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    void Ragdoll()
    {
        {
            Ragdoll r = gameObject.GetComponentInParent<Ragdoll>();
            if (r != null)
            {
                r.ragdollOn = true;
            }
        }
    }
}

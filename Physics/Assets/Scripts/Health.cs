using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    [SerializeField] private int startingHealth = 1;
    public int currentHealth;
    [SerializeField] FloatVariable numberOfActiveEnemies;
    [SerializeField] GameObject hitVFX;
    [SerializeField] GameObject hitVFXSpawnPoint;

    private bool isAlive = true;



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

        GameObject hitVFX = ObjectPooler.SharedInstance.GetPooledObject("Blood");
        hitVFX.transform.position = hitVFXSpawnPoint.transform.position;
        hitVFX.SetActive(true);

        if (currentHealth <= 0 && isAlive)
            Die();
    }

    private void Die()
    {
        isAlive = false;
        numberOfActiveEnemies.RuntimeValue -= 1;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        Ragdoll(true);
        Invoke("DestroyEnemy", 4f);
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
}

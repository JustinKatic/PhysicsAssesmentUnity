/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: shoots a projectile if can shoot is made active from enemy move script.
 *shot happens every time timer reaches 0 and is reset back to _timeBetweenShots var.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public bool m_canShoot = false;

    private float m_shotCounter;
    [SerializeField] float m_timeBetweenShots;

    [SerializeField] Transform m_firePoint;
    public float attackRange;

 
    private void OnEnable()
    {
        m_shotCounter = m_timeBetweenShots;
    }


    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        m_shotCounter -= Time.deltaTime;

        if (m_canShoot && m_shotCounter <= 0)
        {
            GameObject projectile = ObjectPooler.m_sharedInstance.GetPooledObject("Projectile");
            projectile.transform.position = m_firePoint.position;
            projectile.transform.rotation = m_firePoint.transform.rotation;
            projectile.SetActive(true);

            m_shotCounter = m_timeBetweenShots;
            m_canShoot = false;
        }

    }
}

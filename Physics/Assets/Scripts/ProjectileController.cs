/************************************************************************************************************************
 *Name: Justin Katic  
 *Description: handles enemies projectiles translates the projectile forward each frame.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] protected float m_speed;
    [SerializeField] protected float m_bulletLife;
    [SerializeField] protected float m_damage;


    private void OnEnable()
    {
        Invoke("SetUnActive", m_bulletLife);
    }

    void Update()
    {
        //Move bullet forward
        MoveBullet();
    }

    virtual protected void MoveBullet()
    {
        transform.Translate(Vector3.forward * m_speed * Time.deltaTime);
    }

    virtual protected void SetUnActive()
    {
        gameObject.SetActive(false);
        CancelInvoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().Hurt(m_damage);
            gameObject.SetActive(false);
            CancelInvoke();
        }
    }
}

/************************************************************************************************************************
 *Name: Justin Katic
 *Date Created: Thurs April 1 2021
 *Description: Granade projectile behaviour handles when granade explodes after thrown aswell as its interaction with other
 *objects. casts a sphere cast after x seconds and applying dmg if a health exists and forces to objects without the ignoreLayer
 *layer.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    Rigidbody rb;
    public float m_granadeSpeed = 500f;
    public float m_explosionForce = 2000;
    public float m_explosionRadius = 30;

    public GameObject m_explosionEffect;

    public LayerMask m_ignoreLayer;

    public ScriptableSoundObj m_granadeExplosion;




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.forward * m_granadeSpeed);
        StartCoroutine(Explode());
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);

        m_granadeExplosion.Play();

        Instantiate(m_explosionEffect, transform.position, m_explosionEffect.transform.rotation);

       Collider[] objectsHit = Physics.OverlapSphere(transform.position, m_explosionRadius, ~m_ignoreLayer);
        {
            for (int i = 0; i < objectsHit.Length; i++)
            {
                  if(objectsHit[i].gameObject.GetComponent<Rigidbody>() != null)
                {
                    if(objectsHit[i].transform.gameObject.GetComponentInParent<EnemyHealth>() != null)
                    {
                        objectsHit[i].transform.gameObject.GetComponentInParent<EnemyHealth>().TakeDamage(50);
                    }
                    objectsHit[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(m_explosionForce, transform.position, 100);
                }
            }
            gameObject.SetActive(false);
        }
    }
}

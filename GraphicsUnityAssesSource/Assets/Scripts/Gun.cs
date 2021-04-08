/************************************************************************************************************************
 *Name: Justin Katic 
 *Date Created: Thurs April 1 2021
 *Description: Handles players shooting and throwing granades.
 *Shoot- If timers are greater then fire rate player can shoot raycast if target has health apply damage.
 *granade- If timers are greater then fire rate player can spawn granade. grande script will handle its movement.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    [SerializeField] [Range(0f, 1.5f)] private float m_fireRate = 1;
    [SerializeField] [Range(1, 10)] private int m_damage = 1;

    private float m_gunTimer;

    private float m_granadeTimer;

    public GameObject m_shootPoint;

    public GameObject m_granadeShootPoint;

    public float m_hitForce = 500;

    public LayerMask m_layersToIgnore;

    public GameObject m_shootEffect;

    public GameObject m_granade;

    public ScriptableSoundObj m_gunShot;


    void Update()
    {

        m_gunTimer += Time.deltaTime;
        if (m_gunTimer >= m_fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                m_gunTimer = 0f;
                m_shootEffect.SetActive(true);
                fireGun();
            }
            else
                m_shootEffect.SetActive(false);
        }

        m_granadeTimer += Time.deltaTime;
        if (m_granadeTimer >= m_fireRate)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                m_granadeTimer = 0f;
                fireGranade();
            }
        }
    }

    private void fireGranade()
    {
        Instantiate(m_granade, m_granadeShootPoint.transform.position, m_granadeShootPoint.transform.rotation);
    }

    private void fireGun()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);


        m_gunShot.Play();

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 200f, ~m_layersToIgnore))
        {

            EnemyHealth health = hitInfo.transform.gameObject.GetComponentInParent<EnemyHealth>();

            if (health != null)
            {
                if (hitInfo.transform.gameObject.name == "Head")
                {
                    Ragdoll ragdoll = hitInfo.transform.gameObject.GetComponentInParent<Ragdoll>();

                    ragdoll.m_rigidbodies.RemoveAt(ragdoll.m_rigidbodies.Count - 1);
                    Destroy(hitInfo.transform.gameObject.GetComponent<CharacterJoint>());
                    hitInfo.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    health.TakeDamage(50);
                }

                health.TakeDamage(m_damage);
            }
            if (hitInfo.rigidbody != null)
                hitInfo.rigidbody.AddForce(-hitInfo.normal * m_hitForce);
        }
    }
}

/************************************************************************************************************************
 *Name: Justin Katic
 *Date Created: Thurs April 1 2021
 *Description: simple enemy move script using nav agent. different speeds/behaviours are applied if the player is invis or
 *if the slow affect is active on enemy.
 *Tells the enemy shoot script if it is able to shoot based of distance to player.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    NavMeshAgent m_agent;
    Transform m_player;

    public BoolVariable m_isInvisActive;
    public BoolVariable m_isSnowActive;

    public float m_moveSpeed;


    EnemyShoot m_enemyShoot;
    EnemyHealth m_health;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
        m_enemyShoot = gameObject.GetComponent<EnemyShoot>();
        m_health = gameObject.GetComponent<EnemyHealth>();
    }


    // Update is called once per frame
    void Update()
    {
        if (m_health.m_isAlive)
        {
            float distBetweenSelfAndPlayer = Vector3.Distance(transform.position, m_player.position);

            if (m_agent.enabled)
            {
                if (!m_isInvisActive.RuntimeValue)
                {
                    if (distBetweenSelfAndPlayer <= m_enemyShoot.attackRange)
                    {
                        m_enemyShoot.m_canShoot = true;
                        m_agent.velocity = Vector3.zero;
                        m_agent.isStopped = true;
                    }
                    else
                    {
                        m_enemyShoot.m_canShoot = false;
                        m_agent.isStopped = false;
                    }

                    transform.LookAt(m_player);
                    m_agent.destination = m_player.position;
                }
                else
                {
                    m_agent.isStopped = true;
                    m_agent.velocity = Vector3.zero;
                }


                if (!m_isSnowActive.RuntimeValue)
                {
                    m_agent.speed = m_moveSpeed;
                }
                else
                    m_agent.speed = m_moveSpeed / 2;
            }
        }
        else
            m_enemyShoot.m_canShoot = false;
    }
}

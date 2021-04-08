/************************************************************************************************************************
 *Name: Justin Katic  
 *Date Created: Thurs April 1 2021
 *Description: handles player inputs for movement and jump aswell as movement animations for the player.
 *Date Modified: 06/04/2021
 ************************************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float m_moveSpeed;
    public float m_jumpForce;
    public bool m_isJumping;
    public bool m_isGrounded;

    public GameObject m_groundedObj;
    public LayerMask m_ground;
    public float m_groundRayDist;
    private Rigidbody m_rb;

    Animator m_anim;

    private void Start()
    {
        m_rb = gameObject.GetComponent<Rigidbody>();
        m_anim = gameObject.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Move();

        m_isGrounded = IsGrounded();

        if (m_isJumping && m_isGrounded)
        {
            m_anim.SetBool("IsJumping", false);
            m_isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetMouseButtonDown(1))
        {
            m_anim.SetBool("IsAiming", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            m_anim.SetBool("IsAiming", false);
        }
    }

    bool IsGrounded()
    {
        Ray ray = new Ray(m_groundedObj.transform.position, Vector3.down);
        
        if (Physics.Raycast(ray, m_groundRayDist, m_ground))
        {
            Debug.DrawRay(m_groundedObj.transform.position, Vector3.down * m_groundRayDist, Color.red);
            return true;
        }
        return false;
    }

    private void Jump()
    {
        if (m_isGrounded)
        {
            m_anim.SetBool("IsJumping", true);
            m_rb.AddForce(Vector3.up * m_jumpForce, ForceMode.Impulse);
            m_isJumping = true;
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir *= m_moveSpeed;
        dir.y = m_rb.velocity.y;

        m_rb.velocity = dir;

        m_anim.SetFloat("xPos", x);
        m_anim.SetFloat("yPos", z);

    }
}

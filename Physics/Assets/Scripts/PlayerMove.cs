using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool isJumping;
    public bool isGrounded;

    public GameObject groundedObj;
    public LayerMask ground;
    public float groundRayDist;
    public LayerMask ignorelayermask;
    private Rigidbody rb;

    Animator anim;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        Move();

        isGrounded = IsGrounded();

        if (isJumping && isGrounded)
        {
            anim.SetBool("IsJumping", false);
            isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (Input.GetMouseButtonDown(1))
        {
            anim.SetBool("IsAiming", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("IsAiming", false);
        }
    }

    bool IsGrounded()
    {
        Ray ray = new Ray(groundedObj.transform.position, Vector3.down);
        
        if (Physics.Raycast(ray, groundRayDist, ground))
        {
            //Debug.Log("GROUNDED");
            Debug.DrawRay(groundedObj.transform.position, Vector3.down * groundRayDist, Color.red);
            return true;
        }
        return false;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            anim.SetBool("IsJumping", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;

        anim.SetFloat("xPos", x);
        anim.SetFloat("yPos", z);

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public GameObject groundedObj;
    public LayerMask ground;
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

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        if (CanJump())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    bool CanJump()
    {
        Ray ray = new Ray(groundedObj.transform.position, Vector3.down);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 1f,ground))
        {
            return hitInfo.collider != null;
        }
        return false;
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = transform.right * x + transform.forward * z;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;

        if (dir != Vector3.zero)
            anim.speed = 1;
        else
            anim.speed = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] float _speed;
    Rigidbody rb = null;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Move bullet forward
        MoveBullet();
    }

    void MoveBullet()
    {
        rb.velocity = new Vector3(0, 0, _speed);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour
{
    [SerializeField] float TimeBetweenShots;
    public float _shotCounter = 5f;
    [SerializeField] Transform _firePoint;
    [SerializeField] GameObject ball;

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        _shotCounter -= Time.deltaTime;
        if (_shotCounter <= 0)
        {
            Instantiate(ball, _firePoint.transform.position, _firePoint.transform.rotation);
            _shotCounter = TimeBetweenShots;
        }
    }
}

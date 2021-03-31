using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Gun : MonoBehaviour
{
    [SerializeField] [Range(0f, 1.5f)] private float fireRate = 1;
    [SerializeField] [Range(1, 10)] private int damage = 1;

    private float gunTimer;

    private float granadeTimer;

    public GameObject shootPoint;

    public GameObject granadeShootPoint;

    public float hitForce = 500;

    public LayerMask layersToIgnore;

    public GameObject shootEffect;

    public GameObject granade;

    public ScriptableSoundObj gunShot;


    void Update()
    {

        gunTimer += Time.deltaTime;
        if (gunTimer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                gunTimer = 0f;
                shootEffect.SetActive(true);
                fireGun();
            }
            else
                shootEffect.SetActive(false);
        }

        granadeTimer += Time.deltaTime;
        if (granadeTimer >= fireRate)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                granadeTimer = 0f;
                fireGranade();
            }
        }
    }

    private void fireGranade()
    {
        Instantiate(granade, granadeShootPoint.transform.position, granadeShootPoint.transform.rotation);
    }

    private void fireGun()
    {
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);


        gunShot.Play();

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 200f, ~layersToIgnore))
        {

            Health health = hitInfo.transform.gameObject.GetComponentInParent<Health>();

            if (health != null)
            {
                if (hitInfo.transform.gameObject.name == "Head")
                {
                    Ragdoll ragdoll = hitInfo.transform.gameObject.GetComponentInParent<Ragdoll>();

                    ragdoll.rigidbodies.RemoveAt(ragdoll.rigidbodies.Count - 1);
                    Destroy(hitInfo.transform.gameObject.GetComponent<CharacterJoint>());
                    hitInfo.transform.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    health.TakeDamage(50);
                }

                health.TakeDamage(damage);
            }
            if (hitInfo.rigidbody != null)
                hitInfo.rigidbody.AddForce(-hitInfo.normal * hitForce);
        }
    }
}

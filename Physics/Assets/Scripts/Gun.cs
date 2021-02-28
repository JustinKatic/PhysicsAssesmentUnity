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


    public float force = 5f;

    public float pickUpRange;

    public GameObject shootPoint;

    public GameObject granadeShootPoint;


    public LineRenderer lr;

    public float hitForce = 500;

    public LayerMask layersToIgnore;

    public GameObject shootEffect;

    public GameObject granade;

    public ScriptableSoundObj gunShot;


    private void Start()
    {
        lr.material.color = Color.red;
    }
    void Update()
    {
        gunTimer += Time.deltaTime;
        if (gunTimer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                gunTimer = 0f;
                fireGun();
            }
        }

        granadeTimer += Time.deltaTime;
        if (granadeTimer >= fireRate)
        {
            if (Input.GetButton("Fire2"))
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

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;



        lr.SetPosition(0, shootPoint.transform.position);
        if (Physics.Raycast(ray, out hitInfo, 200f, ~layersToIgnore))
        {
            lr.SetPosition(1, hitInfo.point);
            StartCoroutine(ShotEffect());

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


            if (hitInfo.transform.gameObject.name == "PowerBox")
                hitInfo.transform.gameObject.GetComponent<PowerBox>().SpawnBattery();


            if (hitInfo.transform.gameObject.name == "Battery")
                if (hitInfo.distance <= pickUpRange)
                {
                    hitInfo.transform.gameObject.GetComponent<Battery>().AttachItemToPlayer();
                }
        }
    }
    IEnumerator ShotEffect()
    {
        gunShot.Play();
        lr.enabled = true;
        shootEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        lr.enabled = false;
        shootEffect.SetActive(false);

    }
}

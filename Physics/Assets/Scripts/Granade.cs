using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    Rigidbody rb;
    public float granadeSpeed = 500f;
    public float explosionForce = 2000;
    public float explosionRadius = 30;

    public GameObject explosionEffect;

    public LayerMask IgnoreLayer;

    public ScriptableSoundObj granadeExplosion;




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.forward * granadeSpeed);
        StartCoroutine(Explode());
        
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);

        granadeExplosion.Play();

        Instantiate(explosionEffect, transform.position,explosionEffect.transform.rotation);

       Collider[] objectsHit = Physics.OverlapSphere(transform.position, explosionRadius, ~IgnoreLayer);
        {
            for (int i = 0; i < objectsHit.Length; i++)
            {
                  if(objectsHit[i].gameObject.GetComponent<Rigidbody>() != null)
                {
                    if(objectsHit[i].transform.gameObject.GetComponentInParent<Health>() != null)
                    {
                        objectsHit[i].transform.gameObject.GetComponentInParent<Health>().TakeDamage(50);
                    }
                    objectsHit[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, 100);
                }
            }
            gameObject.SetActive(false);
        }
    }
}

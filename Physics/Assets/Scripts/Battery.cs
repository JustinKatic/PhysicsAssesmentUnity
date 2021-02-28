using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    public GameObject pickUpPoint;
    public BoolVariable hasBattery;
    private bool CanPickUp = true;


    public void AttachItemToPlayer()
    {
        if (CanPickUp)
        {
            hasBattery.Value = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.position = pickUpPoint.transform.position;
            gameObject.transform.SetParent(pickUpPoint.transform);
            CanPickUp = false;
        }
    }
}

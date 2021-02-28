using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBattery : MonoBehaviour
{
    public GameEvent BatteryPlaced;
    public BoolVariable HasBattery;
    public GameObject placeBatteryPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Battery")
        {
            if (HasBattery.Value == true)
            {
                BatteryPlaced.Raise();
                HasBattery.Value = false;
                other.gameObject.transform.SetParent(null);
                other.gameObject.transform.position = placeBatteryPos.transform.position;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{
    private bool hasBatterySpawned = false;
    public GameObject battery;
    public void SpawnBattery()
    {
        if (hasBatterySpawned == false)
        {
            battery.SetActive(true);
            hasBatterySpawned = true;
        }
    }
}

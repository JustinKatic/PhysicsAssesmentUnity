using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public int SpawnRate;
    void Start()
    {
        InvokeRepeating("SpawnObj", 1, SpawnRate);
    }

    void SpawnObj()
    {
        Instantiate(objToSpawn, transform.position, Quaternion.identity);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class EarthSpawner : MonoBehaviour
{
    public GameObject Prefab;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        var spawnPoint = GetSpawnPoint();
        Instantiate(Prefab, spawnPoint, Quaternion.identity);
    }

    private Vector3 GetSpawnPoint()
    {
        
        
        return Vector3.zero;
    }
}

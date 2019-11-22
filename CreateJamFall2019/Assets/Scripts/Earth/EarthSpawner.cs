using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpawner : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnPoint = GetSpawnPoint();
    }

    private Vector3 GetSpawnPoint()
    {
        
    }
}

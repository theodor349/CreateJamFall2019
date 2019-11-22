using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.XR;
using Object = UnityEngine.Object;

public class EarthSpawner : MonoBehaviour
{
    public Transform EarthPointer;
    public Transform Map;

    private EarthProperties _earthProperties;

    private void Start()
    {
        _earthProperties = EarthProperties.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SpawnObject();
    }

    private void SpawnObject()
    {
        var spawnPoint = GetSpawnPoint();
        if (spawnPoint == Vector3.zero) 
            return;
        var go = Instantiate(GetObjectToSpawn(), spawnPoint, Quaternion.identity);
        go.transform.SetParent(Map);
        go.transform.Rotate(Vector3.forward, GetRotationOfSpawn(spawnPoint));
    }

    private GameObject GetObjectToSpawn()
    {
        return _earthProperties.SpawnableObjects[0];
    }

    private float GetRotationOfSpawn(Vector3 point)
    {
        var rotation = Math.Atan(point.y / point.x) * 180/Math.PI;
        if (point.x < 0)
            rotation += 180;
        
        return (float)rotation - 90;
    }

    private Vector3 GetSpawnPoint()
    {
        
        RaycastHit2D hit = Physics2D.Raycast(EarthPointer.position, Vector2.down);
        if (hit.collider != null)
        {
            return hit.point;
        }
        
        return Vector3.zero;
    }
}

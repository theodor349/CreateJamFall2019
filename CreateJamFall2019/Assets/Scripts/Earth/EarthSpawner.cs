using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.XR;
using Object = UnityEngine.Object;

public class EarthSpawner : MonoBehaviour
{
    public Transform EarthPointer;
    public Transform EarthCenter;
    public Transform Map;
    public int PlanetLayer = 8;

    private EarthProperties _earthProperties;

    private void Start()
    {
        _earthProperties = EarthProperties.Instance;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetButton("EarthPlant"))
            SpawnObject();
    }

    private void SpawnObject()
    {
        if (!_earthProperties.CanUseSpawnable()) return;
        
        var obj = GetObjectToSpawn();
        var spawnPoint = GetSpawnPoint(obj);
        if (obj.SpawnOnPlanet && spawnPoint == Vector3.zero) return;
        
        var go = Instantiate(obj.Prefab, spawnPoint, Quaternion.identity);
        SetupObject(obj, go);
        _earthProperties.UseSpawnable();
    }

    private void SetupObject(SpawnableObject obj, GameObject go)
    {
        go.transform.SetParent(Map);
        if(obj.SpawnOnPlanet)
            go.transform.Rotate(Vector3.forward, GetRotationOfSpawn(go.transform.position));
    }

    private SpawnableObject GetObjectToSpawn()
    {
        return _earthProperties.SpawnableObjects[_earthProperties.ChosenSpawnable];
    }

    // MAKE SURE THE CENTER OF THE PLANET ALWAYS IS IN (0,0,0)
    private float GetRotationOfSpawn(Vector3 point)
    {
        var rotation = Math.Atan(point.y / point.x) * 180/Math.PI;
        if (point.x < 0)
            rotation += 180;
        
        return (float)rotation - 90;
    }

    private Vector3 GetSpawnPoint(SpawnableObject obj)
    {
        if (!obj.SpawnOnPlanet)
            return EarthPointer.position;

        RaycastHit2D hit = Physics2D.Raycast(EarthPointer.position, Vector2.down, float.MaxValue, 1 << PlanetLayer);
        if (hit.collider != null)
        {
            return hit.point;
        }
        
        return Vector3.zero;
    }
}

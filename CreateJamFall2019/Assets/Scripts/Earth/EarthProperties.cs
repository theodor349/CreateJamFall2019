using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthProperties : MonoBehaviour
{
    public static EarthProperties Instance;

    public float Radius = 2f;
    public float RotationSpeed = 2f;

    public GameObject[] SpawnableObjects;
    
    private void Awake()
    {
        Instance = this;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthProperties : MonoBehaviour
{
    public static EarthProperties Instance;

    public float Radius = 2f;
    public float RotationSpeed = 2f;
    public int ChosenSpawnable = 0;
    public SpawnableObject[] SpawnableObjects;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            PreviousSpawnable();
        else if(Input.GetKeyDown(KeyCode.E))
            NextSpawnable();
    }

    public void NextSpawnable()
    {
        ChosenSpawnable++;
        ChosenSpawnable %= SpawnableObjects.Length;
    }
    
    public void PreviousSpawnable()
    {
        ChosenSpawnable--;
        if (ChosenSpawnable < 0)
            ChosenSpawnable = SpawnableObjects.Length - 1;
    }
}

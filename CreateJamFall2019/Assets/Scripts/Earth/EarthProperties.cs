﻿using System;
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
    public float[] CoolDowns;
    
    private void Awake()
    {
        Instance = this;
        CoolDowns = new float[SpawnableObjects.Length];
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
            PreviousSpawnable();
        else if(Input.GetKeyDown(KeyCode.E))
            NextSpawnable();

        DoCoolDowns();
    }

    public bool CanUseSpawnable()
    {
        return CoolDowns[ChosenSpawnable] <= 0;
    }

    public void UseSpawnable()
    {
        CoolDowns[ChosenSpawnable] = SpawnableObjects[ChosenSpawnable].CoolDown;
    }
    
    private void DoCoolDowns()
    {
        for (int i = 0; i < CoolDowns.Length; i++)
        {
            CoolDowns[i] -= Time.deltaTime;
        }
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

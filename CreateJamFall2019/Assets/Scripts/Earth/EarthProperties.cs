using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthProperties : MonoBehaviour
{
    public static EarthProperties Instance;

    public float Radius = 2f;
    public float MaxRotaionSpeed = 2f;
    public float RotationSpeed = 2f;
    public float MaxRotationAcceleration = 2f;
    
    public int ChosenSpawnable = 0;
    public SpawnableObject[] SpawnableObjects;
    public float[] CoolDowns;
    private UiPlanetPowerSelector UiPlanetPowerSelector;

    [Header("Madness")] 
    public int Madness = 0;
    public int NextLevel = 50;

    void Start()
    {
        UiPlanetPowerSelector = UiPlanetPowerSelector.Instance;
    }

    private void Awake()
    {
        Instance = this;
        CoolDowns = new float[SpawnableObjects.Length];
    }

    private void Update()
    {
        DoMadness();
        
        if(Input.GetAxisRaw("ScroolWheel") < 0)
            PreviousSpawnable();
        else if(Input.GetAxisRaw("ScroolWheel") > 0)
            NextSpawnable();
        
        DoCoolDowns();
    }

    private void DoMadness()
    {
        if (Madness >= NextLevel)
        {
            Debug.Log("Level Up");
            Madness = 0;
        }
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
        UiPlanetPowerSelector.updatePlanetPowerIcons();
    }
    
    public void PreviousSpawnable()
    {
        ChosenSpawnable--;
        if (ChosenSpawnable < 0)
            ChosenSpawnable = SpawnableObjects.Length - 1;
        UiPlanetPowerSelector.updatePlanetPowerIcons();

    }
}

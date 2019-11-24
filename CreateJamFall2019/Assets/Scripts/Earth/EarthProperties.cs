using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public int Level = 0;
    public static Action<int> LevelUp;

    void Start()
    {
        UiPlanetPowerSelector = UiPlanetPowerSelector.Instance;
        RegistreLevelUpAction(NewLevel);
    }

    private void NewLevel(int lvl)
    {
        NextLevel = 10 + Level * 5;
        MaxRotaionSpeed = 10 + (float)Math.Pow(Level,  1.1f);
        MaxRotationAcceleration = 1 + lvl * 8;
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
        if (Madness >= NextLevel || Input.GetKeyDown(KeyCode.L))
        {
            Level++;
            Madness = 0;
            LevelUp?.Invoke(Level);
        }
    }

    public bool CanUseSpawnable()
    {
        if(SpawnableObjects[ChosenSpawnable].name.Equals("Vulcano"))
            if (!EarthPointer.Instance.VulcanoUnlocked)
                return false;
        
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
        var i = UiPlanetPowerSelector;
        UiPlanetPowerSelector.Instance.updatePlanetPowerIcons(-1);
    }
    
    public void PreviousSpawnable()
    {
        ChosenSpawnable--;
        if (ChosenSpawnable < 0)
            ChosenSpawnable = SpawnableObjects.Length - 1;
        UiPlanetPowerSelector.Instance.updatePlanetPowerIcons(-1);
    }

    public static void RegistreLevelUpAction(Action<int> action)
    {
        LevelUp += action;
    }
}

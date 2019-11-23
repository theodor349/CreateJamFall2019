using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiPlanetPowerSelector : MonoBehaviour
{
    public static UiPlanetPowerSelector Instance;
    public SpriteRenderer leftPower;
    public TextMeshProUGUI leftTimer;
    public SpriteRenderer rightPower;
    public TextMeshProUGUI rightTimer;
    public SpriteRenderer currentPower;
    public TextMeshProUGUI currentTimer;
    private EarthProperties earthProperties;

    void Start()
    {
        earthProperties = EarthProperties.Instance;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void updatePlanetPowerIcons()
    {
        if (earthProperties.ChosenSpawnable == 0)
            leftPower.sprite = earthProperties.SpawnableObjects[2].Icon;

        else
            leftPower.sprite = earthProperties.SpawnableObjects[earthProperties.ChosenSpawnable -1].Icon;

        currentPower.sprite = earthProperties.SpawnableObjects[earthProperties.ChosenSpawnable].Icon;

        if(earthProperties.ChosenSpawnable == 2)
            rightPower.sprite = earthProperties.SpawnableObjects[0].Icon;

        else
            rightPower.sprite = earthProperties.SpawnableObjects[earthProperties.ChosenSpawnable + 1].Icon;

    }

    private void Update()
    {
        if (earthProperties.ChosenSpawnable == 0)
        {
            if (earthProperties.CoolDowns[2] <= 0.01f)
                leftTimer.text = "";
            else
                leftTimer.text = earthProperties.CoolDowns[2].ToString();

        }

        else
             if (earthProperties.CoolDowns[earthProperties.ChosenSpawnable - 1] <= 0.01f)
                leftTimer.text = "";
             else
                leftTimer.text = earthProperties.CoolDowns[earthProperties.ChosenSpawnable - 1].ToString();

        if(earthProperties.CoolDowns[earthProperties.ChosenSpawnable] <= 0.01f)
            currentTimer.text = "";
        else
            currentTimer.text = earthProperties.CoolDowns.ToString();

        if (earthProperties.ChosenSpawnable == 2)
        {
            if(earthProperties.CoolDowns[0] <= 0.01f)
                rightTimer.text = "";
            else
                rightTimer.text = earthProperties.SpawnableObjects[0].CoolDown.ToString();
        }

        else
            if(earthProperties.CoolDowns[earthProperties.ChosenSpawnable + 1] <= 0.01f)
                rightTimer.text = "";
            else
                rightTimer.text = earthProperties.CoolDowns[earthProperties.ChosenSpawnable + 1].ToString();
    }
}

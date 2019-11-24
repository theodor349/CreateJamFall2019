using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
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
        updatePlanetPowerIcons(-1);
        EarthProperties.RegistreLevelUpAction(updatePlanetPowerIcons);
    }

    private void Awake()
    {
        Instance = this;
        var i = Instance;
    }

    public void updatePlanetPowerIcons(int level)
    {
        int index = earthProperties.ChosenSpawnable;
        int max = earthProperties.SpawnableObjects.Length;

        var temp = earthProperties.SpawnableObjects[index];
        currentPower.sprite = temp.Icon;
        if(temp.name.Equals("Vulcano") && earthProperties.Level < EarthPointer.Instance.VulcanoLevel)
            currentPower.color = Color.black;
        else 
            currentPower.color = Color.white;
        
        index = Next(index, max);
        temp = earthProperties.SpawnableObjects[index];
        rightPower.sprite = temp.Icon;
        if(temp.name.Equals("Vulcano") && earthProperties.Level < EarthPointer.Instance.VulcanoLevel)
            rightPower.color = Color.black;
        else 
            rightPower.color = Color.white;

        index = Next(index, max);
        temp = earthProperties.SpawnableObjects[index];
        leftPower.sprite = temp.Icon;
        if(temp.name.Equals("Vulcano") && earthProperties.Level < EarthPointer.Instance.VulcanoLevel)
            leftPower.color = Color.black;
        else 
            leftPower.color = Color.white;
    }

    private void Update()
    {
        Cooldowns();
    }

    private void Cooldowns()
    {
        int index = earthProperties.ChosenSpawnable;
        int max = earthProperties.CoolDowns.Length;

        var temp = earthProperties.CoolDowns[index];
        currentTimer.text = temp <= 0.01f ? "" : temp.ToString("0.0");

        index = Next(index, max);
        temp = earthProperties.CoolDowns[index];
        rightTimer.text = temp <= 0.01f ? "" : temp.ToString("0.0");

        index = Next(index, max);
        temp = earthProperties.CoolDowns[index];
        leftTimer.text = temp <= 0.01f ? "" : temp.ToString("0.0");
    }

    private int Next(int index, int max)
    {
        index++;
        if (index == max)
            index = 0;
        return index;
    }
}

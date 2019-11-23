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
        currentPower.sprite = earthProperties.SpawnableObjects[earthProperties.ChosenSpawnable].Icon;

    }


}

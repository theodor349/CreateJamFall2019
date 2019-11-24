using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadnessMeter : MonoBehaviour
{
    public Slider Meter;

    private EarthProperties _earthProperties;
    private float lastValue;

    private void Start()
    {
        _earthProperties = EarthProperties.Instance;
    }

    private void Update()
    {
        var v = (float)_earthProperties.Madness / _earthProperties.NextLevel;
        if(Math.Abs(v - lastValue) < 0.01)
            return;

        Meter.value = v;
        lastValue = v;
    }
}

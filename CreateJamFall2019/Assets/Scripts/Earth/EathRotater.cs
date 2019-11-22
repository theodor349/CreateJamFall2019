using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EathRotater : MonoBehaviour
{
    private EarthProperties _earthProperties;

    private void Start()
    {
        _earthProperties = EarthProperties.Instance;
    }

    private void FixedUpdate()
    {
        transform.Rotate(Time.fixedDeltaTime * _earthProperties.RotationSpeed * Vector3.forward, Space.World);
    }
}
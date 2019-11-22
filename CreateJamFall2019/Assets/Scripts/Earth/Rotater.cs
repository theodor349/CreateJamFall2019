using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotationSpeed = 2f;

    private void FixedUpdate()
    {
        transform.Rotate(Time.fixedDeltaTime * rotationSpeed * Vector3.forward, Space.World);
    }
}
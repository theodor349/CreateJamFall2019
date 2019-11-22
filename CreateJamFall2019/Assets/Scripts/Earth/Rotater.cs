using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float rotationSpeed = 2f;
    public Transform rotationPoint;
    
    void FixedUpdate()
    {
        //transform.RotateAround(rotationPoint.position, Vector3.forward, rotationSpeed * Time.fixedTime);
        transform.Rotate(Vector3.forward * rotationSpeed * Time.fixedDeltaTime, Space.World);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;
using UnityEngine;

public class RotationFall : MonoBehaviour
{
    public float Rotation = 45f;
    public float TimeToFall = 1f;

    private float falledAmount = 0f;
    
    void Update()
    {
        if (Math.Abs(falledAmount) >= Math.Abs(Rotation))
            return;
        
        float fall = Rotation / TimeToFall * Time.deltaTime;
        falledAmount += fall;
        transform.Rotate(Vector3.forward, fall);    
    }
}

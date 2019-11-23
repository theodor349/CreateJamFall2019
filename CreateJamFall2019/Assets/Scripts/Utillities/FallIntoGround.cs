using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class FallIntoGround : MonoBehaviour
{
    public float Distance = 3f;
    public float FallTime = 2f;

    private float falledTime = 0f;
    private float speed;

    private void Start()
    {
        speed = Distance / FallTime;
    }

    private void Update()
    {
        falledTime += FallTime * Time.deltaTime;
        if(falledTime >= FallTime)
            Destroy(gameObject);

        var transform1 = transform;
        var pos = transform1.position;
        pos -= speed * 1 * Time.deltaTime * transform1.up;
        transform1.position = pos;
    }
}

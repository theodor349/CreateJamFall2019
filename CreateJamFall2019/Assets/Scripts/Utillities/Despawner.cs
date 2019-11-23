using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Despawner : MonoBehaviour
{
    public float MinTime = 1f;
    public float MaxTime = 2f;

    private float time;
    private void Start()
    {
        time = Random.Range(MinTime, MaxTime);
    }

    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0)
            Destroy(gameObject);
    }
}

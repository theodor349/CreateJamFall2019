using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float SpawnSpeed = 2f;
    
    private float spawnPercent = 0f;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
    }

    void Update()
    {
        if(spawnPercent >= 1f)
            return;
        
        spawnPercent += Time.deltaTime / SpawnSpeed;
        Grow();
    }

    private void Grow()
    {
        transform.localScale = Vector3.one * spawnPercent;
    }
}

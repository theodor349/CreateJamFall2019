using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDelay : MonoBehaviour
{
    public float Delay = 2f;
    private float delayed = 0f;

    public GameObject[] Spawn;
    
    void Update()
    {
        delayed += Time.deltaTime;
        if (delayed >= Delay)
        {
            foreach (var g in Spawn)
            {
                g.SetActive(true);
            }
        }
    }
}

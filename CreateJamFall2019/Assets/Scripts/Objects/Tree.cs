using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public ObjectLife Life;
    public Spawner SpawnerTree;
    public float TimebetweenKill = 5f;

    private float timeAlive = 0f;
    private bool canKill = false;
    
    private void Update()
    {
        timeAlive += Time.deltaTime;

        if (!canKill && timeAlive > SpawnerTree.SpawnSpeed)
        {
            canKill = true;
            timeAlive = 0f;
        }
        
        if(canKill && timeAlive >= TimebetweenKill)
        {
            Life.Damage();
            timeAlive = 0f;
        }
    }
}

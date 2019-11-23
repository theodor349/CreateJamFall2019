using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectLife : MonoBehaviour
{
    public int Stages = 4;
    public Sprite[] Sprites;
    public SpriteRenderer _renderer;
        
    private int stage;

    private void Start()
    {
        stage = Stages - 1;
        SetSprite();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
            Damage();
        else if(Input.GetKeyDown(KeyCode.G))
            GrowBack();
    }

    public void Damage()
    {
        stage--;
        SetSprite();
        if(stage == 0)
        {
            gameObject.AddComponent<Despawner>();
            var r = gameObject.AddComponent<RotationFall>();
            r.Rotation = Random.value > 0.5 ? -90f : 90f;
            r.TimeToFall = 0.5f;
        }
    }

    private void SetSprite()
    {
        _renderer.sprite = Sprites[stage];
    }

    public void GrowBack()
    {
        stage++;
        if (stage >= Stages)
            stage = Stages - 1;
        SetSprite();
    }
    
}

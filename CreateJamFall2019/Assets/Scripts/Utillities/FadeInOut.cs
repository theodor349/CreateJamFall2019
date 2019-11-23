using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FadeInOut : MonoBehaviour
{
    public SpriteRenderer[] Renderers;
    public float FadeTime = 0.1f;
    public bool FadeIn;

    private void Start()
    {
        foreach (var spriteRenderer in Renderers)
        {
            var color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }
    }

    public void StartFade()
    {
        FadeIn = true;
        UpdateSprite();
    }

    public void StopFade()
    {
        FadeIn = false;
        UpdateSprite();
    }
    
    private void UpdateSprite()
    {
        foreach (var renderer in Renderers)
        {
            if(FadeIn)
                renderer.color = Color.Lerp(renderer.color, Color.clear, FadeTime);
            else 
                renderer.color = Color.Lerp(renderer.color, Color.white, FadeTime);
        }
    }
}

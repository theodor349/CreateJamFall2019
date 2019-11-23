using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public SpriteRenderer rendere1;
    public SpriteRenderer rendere2;
    public float FadeTime = 1f;

    public float fade = 0f;

    private void OnEnable()
    {
        fade = 0f;
    }

    private void Update()
    {
        fade += FadeTime * Time.deltaTime;
        var color = rendere1.color;
        color.a = 256f * fade;
        rendere1.color = color;
        rendere2.color = color;
    }

    public void FadeOut()
    {
        
    }
}

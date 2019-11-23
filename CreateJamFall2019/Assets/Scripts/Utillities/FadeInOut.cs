using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FadeInOut : MonoBehaviour
{

    [SerializeField] private SpriteRenderer[] Renderers;
    [SerializeField] private float fadeInSpeed = 4f;
    [SerializeField] private float fadeOutSpeed = 2f;

    private bool FadeIn;

    private void Start()
    {
        foreach (var spriteRenderer in Renderers)
        {
            var color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
        }
    }

    private void Update()
    {
        foreach (var renderer in Renderers)
        {
            if (FadeIn)
                renderer.color = Color.Lerp(renderer.color, Color.white, fadeInSpeed * Time.deltaTime);
            else
                renderer.color = Color.Lerp(renderer.color, Color.clear, fadeOutSpeed * Time.deltaTime);
        }
    }

    public void StartFade()
    {
        FadeIn = true;
    }

    public void StopFade()
    {
        FadeIn = false;
    }
}

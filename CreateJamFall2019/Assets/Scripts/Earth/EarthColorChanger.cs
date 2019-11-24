using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthColorChanger : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public int Steps = 20;

    private void Start()
    {
        EarthProperties.RegistreLevelUpAction(LevelUp);
    }

    private void LevelUp(int level)
    {
        Renderer.color = Color.Lerp(Renderer.color, Color.red, t: 1f / Steps);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeponSwupper : MonoBehaviour
{
    public SpriteRenderer Renderer;
    public Sprite Gun;
    public SpawnableObject Crate;

    private bool isGun = true;
    
    private void Update()
    {
        if (Input.GetButtonDown("P1LeftSwitch"))
        {
            SwapWeapon();
        }
    }

    private void SwapWeapon()
    {
        isGun = !isGun;
        Renderer.sprite = isGun ? Gun : Crate.Icon;
    }
}

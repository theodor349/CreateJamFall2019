using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item { Pistol = 0, Crate, Pickaxe };

public class WeponSwupper : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Sprite pistolSprite;
    public Sprite pickaxeSprite;
    public SpawnableObject crate;

    public Item currentItem;
    public bool IsPlayer1;

    private void Update()
    {
        if (IsPlayer1)
        {
            if (Input.GetButtonDown("P1LeftSwitch"))
            {
                SwapWeapon(false);
            }
            if (Input.GetButtonDown("P1RightSwitch"))
            {
                SwapWeapon(true);
            }
        }
        else
        {
            if (Input.GetButtonDown("P2LeftSwitch"))
            {
                SwapWeapon(false);
            }
            if (Input.GetButtonDown("P2RightSwitch"))
            {
                SwapWeapon(true);
            }

        }
    }

    private void SwapWeapon(bool nextWeapon)
    {
        if (nextWeapon) currentItem++;
        else currentItem--;

        if((int)currentItem > Enum.GetNames(typeof(Item)).Length - 1)
            currentItem = 0;
        if ((int)currentItem < 0)
            currentItem = (Item)(Enum.GetNames(typeof(Item)).Length - 1);


        switch (currentItem)
        {
            case Item.Pistol:
                renderer.sprite = pistolSprite;
                break;
            case Item.Crate:
                renderer.sprite = crate.Icon;
                break;
            case Item.Pickaxe:
                renderer.sprite = pickaxeSprite;
                break;
        }
    }
}

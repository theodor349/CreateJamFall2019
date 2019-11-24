using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;

public class Digger : MonoBehaviour
{
    public WeponSwupper weapon;
    public float DigDistance = 1f;
    public Transform GunPoint;
    public LayerMask HitLayer;
    public bool IsPlayer1;

    [SerializeField] private float mineRate = 0.5f;
    private float nextMineTime;

    private void Update()
    {
        if (weapon.currentItem == Item.Pickaxe)
        {
            if (IsPlayer1)
            {
                if ((Input.GetButton("P1Shoot") || Input.GetAxisRaw("P1Trigger") == 1) && Time.time > nextMineTime)
                {
                    nextMineTime = Time.time + mineRate;
                    Mine();
                }
            }
            else
            {
                if ((Input.GetButton("P2Shoot") || Input.GetAxisRaw("P2Trigger") == 1) && Time.time > nextMineTime)
                {
                    nextMineTime = Time.time + mineRate;
                    Mine();
                }
            }
        }
    }

    private void Mine()
    {
        var hit = GetHit();
        if (hit.collider == null)
            return;

        if (hit.transform.tag.Equals("Vulcano"))
        {
            hit.transform.GetComponent<Vulcano>().Damage(hit.point);
            AudioController.Play(Sound.Mine);
        }
        else
        {
            hit.transform.GetComponent<ObjectLife>().Damage();
            AudioController.Play(Sound.Wood);
        }

        EarthProperties.Instance.Madness++;
    }

    private RaycastHit2D GetHit()
    {
        return Physics2D.Raycast(GunPoint.position, transform.right, DigDistance, HitLayer);
    }
}

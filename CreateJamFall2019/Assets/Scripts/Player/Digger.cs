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

    private void Update()
    {
        if (Input.GetButtonDown("P1Mine"))
            Mine();
    }

    private void Mine()
    {
        var c =GetCollider();
        if (c == null)
            return;
        
        c.GetComponent<ObjectLife>().Damage();
    }

    private Collider2D GetCollider()
    {
        return Physics2D.Raycast(GunPoint.position, transform.right, DigDistance, HitLayer).collider;
    }
}

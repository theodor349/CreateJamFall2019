using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class Digger : MonoBehaviour
{
    public WeponSwupper weapon;
    public Transform GunPoint;
    public float DigDistance = 1f;
    public LayerMask HitLayers;
    
    private void Update()
    {
        if (Input.GetButtonDown("P1Mine"))
            Mine();
    }

    private void Mine()
    {
        var col = GetColliderInFront();
        if(col == null)
            return;

        col.transform.GetComponent<ObjectLife>().Damage();
    }

    private Collider2D GetColliderInFront()
    {
        return Physics2D.Raycast(GunPoint.position, transform.right, DigDistance, HitLayers).collider;
    }
}

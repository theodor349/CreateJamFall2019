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
        var hit = GetHit();
        if (hit.collider == null)
            return;
        
        if(hit.transform.tag.Equals("Vulcano"))
            hit.transform.GetComponent<Vulcano>().Damage(hit.point);
        else 
            hit.transform.GetComponent<ObjectLife>().Damage();
    }

    private RaycastHit2D GetHit()
    {
        return Physics2D.Raycast(GunPoint.position, transform.right, DigDistance, HitLayer);
    }
}

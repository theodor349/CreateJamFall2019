using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPointer : MonoBehaviour
{
    public float yHeight = 5f;
    
    private void Update()
    {
        var mouseXPos = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector3(mouseXPos, yHeight, 0f);
    }
}

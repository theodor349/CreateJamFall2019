using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPointer : MonoBehaviour
{
    public float MoveSpeed = 2f;
    private float yHeight = 5f;

    private void Start()
    {
        yHeight = transform.position.y;
    }

    private void Update()
    {
        var mouseXPos = transform.position.x;
        mouseXPos += MoveSpeed * Time.deltaTime * Input.GetAxisRaw("P1Horizontal");
        transform.position = new Vector3(mouseXPos, yHeight, 0f);
    }
}

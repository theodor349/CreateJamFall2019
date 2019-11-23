using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPointer : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float MaxMove = 10f;
    private float yHeight = 5f;

    private void Start()
    {
        yHeight = transform.position.y;
    }

    private void Update()
    {
        var xPos = transform.position.x;
        xPos += MoveSpeed * Time.deltaTime * Input.GetAxisRaw("MouseMoveX");

        if (xPos > MaxMove)
            xPos = MaxMove;
        else if (xPos < -MaxMove)
            xPos = -MaxMove;
        transform.position = new Vector3(xPos, yHeight, 0f);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EathRotater : MonoBehaviour
{
    public float DragSpeed = 2f;
    
    private EarthProperties _earthProperties;
    private bool dragStarted;
    private float lastSpeed = 0f;
    
    private void Start()
    {
        _earthProperties = EarthProperties.Instance;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
            dragStarted = true;
        else if (Input.GetMouseButtonUp(1))
            dragStarted = false;

        if (dragStarted)
        {
            IncreaseRotationSpeed(-Input.GetAxisRaw("MouseMoveX"));
        }
    }

    private void IncreaseRotationSpeed(float v)
    {
        float max = _earthProperties.MaxRotaionSpeed;
        float speed = _earthProperties.RotationSpeed;
        speed += v * DragSpeed * Time.deltaTime;

        if (speed > max)
            speed = max;
        else if (speed < -max)
            speed = -max;
        _earthProperties.RotationSpeed = speed;
    }

    private void FixedUpdate()
    {
        float max = _earthProperties.MaxRotationAcceleration;
        float s = _earthProperties.RotationSpeed;
        
        float a = _earthProperties.RotationSpeed - lastSpeed;
        if (a > max)
            a = max;
        else if (a < -max)
            a = -max;
        s = lastSpeed + a;
        
        var r = Time.fixedDeltaTime * s * Vector3.forward;
        transform.Rotate(r, Space.World);

        //transform.Rotate(Time.fixedDeltaTime * _earthProperties.RotationSpeed * Vector3.forward, Space.World);

        lastSpeed = s;
    }
}
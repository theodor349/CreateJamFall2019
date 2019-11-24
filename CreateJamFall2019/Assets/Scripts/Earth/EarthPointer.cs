using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EarthPointer : MonoBehaviour
{
    public float MoveSpeed = 2f;
    public float MaxMove = 10f;
    private float yHeight = 5f;
    public bool VulcanoUnlocked;
    public int VulcanoLevel = 1;
    public static EarthPointer Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        yHeight = transform.position.y;
        Cursor.lockState = CursorLockMode.Locked;
        
        EarthProperties.RegistreLevelUpAction(LevelUp);
    }

    private void LevelUp(int level)
    {
        if(level == VulcanoLevel)
            VulcanoUnlocked = true;
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

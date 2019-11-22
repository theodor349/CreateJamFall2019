using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 2f;
    private Rigidbody2D rbody;
    private Vector3 playerVelocity;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        playerVelocity = rbody.velocity;

        if(Input.GetKey(KeyCode.W)) 
            
    }
}

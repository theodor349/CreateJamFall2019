using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float runSpeed = 2f;
    [SerializeField]
    private float stickToGroundForce = 9.8f;
    [SerializeField]
    private float friction = 0.1f;

    private Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 vel = new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0);
        rbody.velocity += vel * Time.deltaTime;

        Vector2 frictionVel = rbody.velocity;
        frictionVel.x *= friction;

        rbody.velocity = frictionVel;
    }
}

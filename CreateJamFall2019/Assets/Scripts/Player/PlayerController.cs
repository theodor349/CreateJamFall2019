﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float runSpeed = 10f;
    [SerializeField]
    private float stopSpeed = 15f;
    [SerializeField]
    private float jumpSpeed = 8f;
    [SerializeField]
    SpriteRenderer spriteRenderer;

    private Rigidbody2D rbody;
    private bool wishJump;
    private int collisionCount;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        wishJump = Input.GetKeyDown(KeyCode.Space);

        Vector2 vel = new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0);
        rbody.velocity += vel * Time.deltaTime;

        if (vel.x > 0)
            spriteRenderer.flipX = true;
        else if (vel.x < 0)
            spriteRenderer.flipX = false;

        Vector2 v = rbody.velocity;
        if (rbody.velocity.x > 0 && vel.x < 0)
            v.x -= stopSpeed * Time.deltaTime;
        else if (rbody.velocity.x < 0 && vel.x > 0)
            v.x += stopSpeed * Time.deltaTime;

        if (collisionCount > 0 && wishJump) {
            wishJump = false;
            v.y = jumpSpeed;
        }

        rbody.velocity = v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionCount++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collisionCount--;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float stopSpeed = 20f;
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayers;

    private Rigidbody2D rbody;
    private bool isGrounded;
    private bool wishJump;
    private float groundedRadius = 0.2f;

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, groundLayers);

        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) 
                isGrounded = true;
        }

        wishJump = Input.GetButtonDown("P1Jump");

        Vector2 vel = new Vector2(Input.GetAxis("P1Horizontal") * runSpeed, 0);
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

        if (isGrounded && wishJump) {
            wishJump = false;
            v.y = jumpSpeed;
        }

        rbody.velocity = v;

        if(rbody.position.y < -20)
            rbody.position = new Vector2(0, 3);
    }
}
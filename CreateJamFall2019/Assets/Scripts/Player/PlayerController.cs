using System.Collections;
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

    private float gravScale;
    private Rigidbody2D rbody;
    private bool canJump;
    private bool wishJump;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        gravScale = rbody.gravityScale;
    }

    void Update()
    {
        wishJump = Input.GetKeyDown(KeyCode.Space);

        Vector2 vel = new Vector2(Input.GetAxis("Horizontal") * runSpeed, 0);
        rbody.velocity += vel * Time.deltaTime;

        Vector2 v = rbody.velocity;
        if (rbody.velocity.x > 0 && vel.x < 0)
            v.x -= stopSpeed * Time.deltaTime;
        else if (rbody.velocity.x < 0 && vel.x > 0)
            v.x += stopSpeed * Time.deltaTime;

        if (canJump && wishJump) {
            wishJump = false;
            canJump = false;
            v.y = jumpSpeed;
        }

        rbody.velocity = v;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
}

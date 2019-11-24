using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float stopSpeed = 20f;
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private Transform playerGraphics;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private Transform weapon;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayers;

    private ScoreController scoreController;

    [HideInInspector]
    public Rigidbody2D rbody;
    [HideInInspector]
    public bool isGrounded;
    private bool wishJump;
    private float groundedRadius = 0.1f;
    [HideInInspector]
    public bool isTurnedLeft = true;

    private void Awake() {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        scoreController = ScoreController.Instance;
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
            FlipSprites(true);
        else if (vel.x < 0)
            FlipSprites(false);

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

        if(rbody.position.y < -20) {
            rbody.position = new Vector2(0, 7);
            rbody.velocity = Vector2.zero;
            Camera.main.GetComponent<CameraShake>().Shake();

            scoreController.CheckForNewScore();
            scoreController.ResetRoundTime();
        }
    }

    private void FlipSprites(bool isLeft)
    {
        if(isTurnedLeft == isLeft)
            return;
        isTurnedLeft = isLeft;
        
        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.flipX = isLeft;
        }

        var s = weapon.localScale;
        s.x *= -1;
        weapon.localScale = s;

        var p = weapon.localPosition;
        p.x *= -1;
        weapon.localPosition = p;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Fireball")
        {
            Vector2 force = playerGraphics.up * 500f;
            rbody.velocity += force * Time.deltaTime;
        }
    }
}
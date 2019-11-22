using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float runSpeed = 2f;
    private Rigidbody2D rbody;

    [SerializeField]
    private float gravityStrength = 9.8f;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rbody.velocity += new Vector2(Input.GetAxis("Horizontal"), 0) * runSpeed * Time.deltaTime;
        Physics.gravity = gravityStrength * (Vector3.zero - transform.position);
        Debug.DrawRay(transform.position, Physics.gravity, Color.red);
    }
}

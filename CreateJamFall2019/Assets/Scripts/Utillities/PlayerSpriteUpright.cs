using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteUpright : MonoBehaviour
{
    private Rigidbody2D rbody;


    private void Awake()
    {
        rbody = transform.root.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 gravDir = Vector2.zero - rbody.position;
        transform.up = -gravDir;
    }
}

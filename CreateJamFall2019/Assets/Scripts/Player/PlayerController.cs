using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float runSpeed = 2f;
    private Rigidbody2D rbody;

    private void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    Vector2 GetInput()
    {
        Vector2 inp = new Vector2();

        return inp;
    }
}

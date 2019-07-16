using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocity = 10f;

    void Start()
    {
        Physics.gravity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.y > 0.125)
        {
            //Physics.gravity = new Vector2(0, -1f);
        }
            else
        {
            Physics.gravity = Vector2.zero;
        }

        if (Input.GetKeyDown("up"))
        {
            rb.velocity = Vector2.up * 5;
        }


    }
}

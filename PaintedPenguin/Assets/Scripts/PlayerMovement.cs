using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocity = 10f;
    public string position;
    public BoxCollider2D groundCollider;
    public bool dead;
    public int colour = 0;

    void Start()
    {
        dead = false;
        Physics.gravity = Vector2.zero;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Check where player position is
        if (transform.position.y > 0.12 && transform.position.y < 0.13)
        {
            position = "ground";
        }

        if (transform.position.y >= 0.13)
        {
            position = "air";
        }

        if (transform.position.y <= 0.12)
        {
            position = "water";
        }

        if (transform.position.y > 0.126706)
        {
            //Physics.gravity = new Vector2(0, -1f);
        }
            else
        {
            Physics.gravity = Vector2.zero;
        }

        //Jump or swim only on the ground
        if (position == "ground")
        {
            //Jump
            if (Input.GetKeyDown("up"))
            {
                rb.velocity = Vector2.up * 4;
            }

            //Swim
            if (Input.GetKeyDown("down"))
            {
                rb.velocity = Vector2.down * 4;
                groundCollider.enabled = false;
            }
        }

        //Super jump from dive
        if (Input.GetKeyDown("up") && position == "water")
        {
            rb.velocity = Vector2.up * 8;
        }

        //Super dive from jump
        if (Input.GetKeyDown("down") && transform.position.y > 0.89)
        {
            rb.velocity = Vector2.down * 8;
        }

        Debug.Log(dead);
    }
}

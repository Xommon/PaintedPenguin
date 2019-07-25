using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameManager gameManager;
    public float velocity = 10f;
    public string position;
    public bool dead;
    public int colour = 0;

    void Start()
    {
        dead = false;
        rb = GetComponent<Rigidbody2D>();
        position = "walking";
    }

    void Update()
    {
        //Snap to ground if walking
        if (transform.position.y != -0.075 && position == "walking")
        {
            transform.position = new Vector3(-0.33f, -0.075f, 0);
        }

        //Player starts walking if it falls to the ground
        if ((transform.position.y <= -0.075) && position == "falling")
        {
            position = "walking";
        }

        //Player starts walking if it resurfaces
        if ((transform.position.y >= -0.075) && position == "resurfacing")
        {
            position = "walking";
        }

        //Jump or swim only on the ground
        if (position == "walking")
        {
            //Jump
            if (Input.GetKeyDown("up"))
            {
                position = "jumping";
                rb.gravityScale = 1;
                rb.velocity = Vector2.up * 4;
            }

            //Swim
            if (Input.GetKeyDown("down"))
            {
                position = "diving";
                rb.gravityScale = -1;
                rb.velocity = Vector2.down * 4;
            }
        }

        //Mark player as falling
        if (position == "jumping" && rb.velocity.y < -0.1)
        {
            position = "falling";
        }

        //Mark player as resurfacing
        if (position == "diving" && rb.velocity.y > 0.1)
        {
            position = "resurfacing";
        }

        //If player is falling or resurfacing near the ground, then switch back to walking
        //if ((position == "falling" || position == "resurfacing") && transform.position.y == -0.075f)
        //{
        //    position = "walking";
        //}

        //Super jump from dive
        //if (Input.GetKeyDown("up") && position == "water")
        //{
        //    rb.velocity = Vector2.up * 8;
        //}

        //Super dive from jump
        //if (Input.GetKeyDown("down") && transform.position.y > 0.89)
        //{
        //    rb.velocity = Vector2.down * 8;
        //}

        //Debug.Log(dead);
    }

    //End the game if collision with block occurs
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Block")
        {
            dead = false;
            Debug.Log("Hit block");
            gameManager.GameOver();
        }
    }
}

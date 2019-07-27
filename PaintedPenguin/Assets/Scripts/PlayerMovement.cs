using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public GameManager gameManager;
    public float velocity = 10f;
    public string position;
    public bool dead;
    public int colour = 0;

    void Start()
    {
        dead = false;
        animator.SetBool("dead", false);
        rb = GetComponent<Rigidbody2D>();
        position = "ready";
        rb.gravityScale = 0;
    }

    void Update()
    {
        if (position == "ready")
        {
            // Player is out of sight, ready to start
            transform.position = new Vector3(-1.0f, -0.075f, 0);
            dead = false;
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
            animator.SetBool("swimming", false);
            animator.SetBool("dead", false);
        }

        // Player walks to starting position
        if (position == "starting")
        {
            rb.velocity = transform.right;

            // Start game if player is in position, start the game
            if (transform.position.x >= -0.33)
            {
                gameManager.on = true;
                position = ("walking");
            }
        }

        if (dead == false)
        {
            // Snap to ground if walking
            if (transform.position.y != -0.075 && position == "walking")
            {
                transform.position = new Vector3(-0.33f, -0.075f, 0);
                animator.SetBool("jumping", false);
                animator.SetBool("falling", false);
                animator.SetBool("swimming", false);
            }

            // Player starts walking if it falls to the ground or resurfaces from water
            if ((transform.position.y <= -0.075 && position == "falling") || ((transform.position.y >= -0.075) && position == "resurfacing"))
            {
                position = "walking";
                animator.SetBool("falling", false);
                animator.SetBool("swimming", false);

            }

            // Jump or swim only on the ground
            if (position == "walking")
            {
                //Jump
                if (Input.GetKeyDown("up"))
                {
                    position = "jumping";
                    rb.gravityScale = 1;
                    rb.velocity = Vector2.up * 4;
                    animator.SetBool("jumping", true);
                }

                // Swim
                if (Input.GetKeyDown("down"))
                {
                    position = "diving";
                    rb.gravityScale = -1;
                    rb.velocity = Vector2.down * 4;
                    animator.SetBool("swimming", true);
                }
            }

            // Mark player as falling
            if (position == "jumping" && rb.velocity.y < -0.1)
            {
                position = "falling";
                animator.SetBool("jumping", false);
                animator.SetBool("falling", true);
            }

            // Mark player as resurfacing
            if (position == "diving" && rb.velocity.y > 0.1)
            {
                position = "resurfacing";
            }

            //SUPER jump from dive | && (velocity > -0.5 && velocity < 0.5)
            //if (Input.GetKeyDown("up") && (position == "diving" || position == "resurfacing"))
            //{
            //    position = "superjumping";
            //    rb.gravityScale = 1;
            //    rb.velocity = Vector2.up * 6;
            //}

            //SUPER dive from jump
            //if (Input.GetKeyDown("down") && transform.position.y > 0.89)
            //{
            //    rb.velocity = Vector2.down * 8;
            //}

            //Debug.Log(dead);
        }
    }

    // End the game if collision with block occurs
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Block")
        {
            dead = false;
            animator.SetBool("dead", true);
            Debug.Log("Hit block");
            //gameManager.GameOver();
        }
    }
}

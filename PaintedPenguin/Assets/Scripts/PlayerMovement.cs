using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;
    public GameManager gameManager;
    public string position;
    public bool dead;
    public int colour;

    void Start()
    {
        dead = false;
        animator.SetBool("dead", false);
        rb = GetComponent<Rigidbody2D>();
        position = "ready";
        rb.gravityScale = 0;
    }

    public void Jump()
    {
        if (gameManager.paused == false)
        {
            position = "jumping";
            rb.gravityScale = 1;
            rb.velocity = Vector2.up * 4;
            animator.SetBool("jumping", true);
        }
    }

    public void Dive()
    {
        if (gameManager.paused == false)
        {
            position = "diving";
            rb.gravityScale = -1;
            rb.velocity = Vector2.down * 4;
            animator.SetBool("swimming", true);
        }
    }

    void Update()
    {
        if (position == "ready")
        {
            // Player is out of sight, ready to start
            transform.position = new Vector3(-1.0f, -0.075f, 0);
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
            animator.SetBool("swimming", false);
            animator.SetBool("dead", false);
            dead = false;
        }

        // Player walks to starting position
        if (position == "starting" && dead == false)
        {
            rb.velocity = transform.right;
            animator.SetBool("dead", false);

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
                    Jump();
                }

                // Swim
                if (Input.GetKeyDown("down"))
                {
                    Dive();
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
        }
        else
        {
            //position = "dead";
        }

        // White
        if (colour == 0)
        {
            sr.color = new Color(1f, 1f, 1f, 1f);
        }

        // Red
        if (colour == 1)
        {
            sr.color = new Color(1f, 0.1f, 0.1f, 1f);
        }

        // Orange
        if (colour == 2)
        {
            sr.color = new Color(1f, 0.5f, 0.1f, 1f);
        }

        // Yellow
        if (colour == 3)
        {
            sr.color = new Color(1f, 1f, 0.1f, 1f);
        }

        // Green
        if (colour == 4)
        {
            sr.color = new Color(0.1f, 1f, 0.1f, 1f);
        }

        // Blue
        if (colour == 5)
        {
            sr.color = new Color(0.1f, 0.2f, 1f, 1f);
        }

        // Purple
        if (colour == 6)
        {
            sr.color = new Color(0.7f, 0.1f, 1f, 1f);
        }

        if (dead == true)
        {
            animator.SetBool("dead", true);
        }
    }

    // End the game if collision with an obstacle occurs
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Block(Clone)")
        {
            if (collision.gameObject.GetComponent<Block>().colour != colour && dead == false)
            {
                rb.gravityScale = 0;
                dead = true;
                animator.SetBool("jumping", false);
                animator.SetBool("falling", false);
                animator.SetBool("swimming", false);
                rb.velocity = Vector2.up * 2;
                rb.gravityScale = 0.5f;
                // Time.timeScale = 0.25f;
                Invoke("Death", 0.5f);
                Destroy(collision.gameObject);
            } else if (collision.gameObject.GetComponent<Block>().hit == false && dead == false)
            {
                gameManager.score += 5;
                collision.gameObject.GetComponent<Block>().hit = true;
                Destroy(collision.gameObject);
            }
        }

        if (collision.transform.tag == "Paint")
        {
            colour = collision.gameObject.GetComponent<Paint>().colour;
            Destroy(collision.gameObject);
        }
    }

    public void Death()
    {
        gameManager.GameOver();
    }
}

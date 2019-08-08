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

    // Swipe controls
    public Vector3 swipeStartPosition;
    public Vector3 swipeEndPosition;
    public float swipeMinDistance = 1000;
    public string swipeDirection;

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
        if (gameManager.paused == false && position == "walking")
        {
            position = "jumping";
            rb.gravityScale = 1;
            rb.velocity = new Vector2(0, 4);
            animator.SetBool("jumping", true);
        }
    }

    public void Dive()
    {
        if (gameManager.paused == false && position == "walking")
        {
            position = "diving";
            rb.gravityScale = -1;
            rb.velocity = new Vector2(0, -4);
            animator.SetBool("swimming", true);
        }
    }

    void Update()
    {
        // Swipe controls
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            swipeStartPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetMouseButtonUp(2))
        {
            swipeEndPosition = Input.mousePosition;

            // If the swipe was long enough
            if (Mathf.Abs(swipeStartPosition.y - swipeEndPosition.y) >= swipeMinDistance)
            {
                if (swipeStartPosition.y > swipeEndPosition.y)
                {
                    swipeDirection = "down";
                    Dive();
                }

                if (swipeStartPosition.y < swipeEndPosition.y)
                {
                    swipeDirection = "up";
                    Jump();
                }
            }
        }

        // Set colour
        if (colour == 7)
        {
            for (int i = 0; i < 6; i++)
            {
                // Red
                if (i == 0)
                {
                    sr.color = new Color(1f, 0.1f, 0.1f, 1f);
                }

                // Orange
                if (i == 1)
                {
                    sr.color = new Color(1f, 0.5f, 0.1f, 1f);
                }

                // Yellow
                if (i == 2)
                {
                    sr.color = new Color(1f, 1f, 0.1f, 1f);
                }

                // Green
                if (i == 3)
                {
                    sr.color = new Color(0.1f, 1f, 0.1f, 1f);
                }

                // Blue
                if (i == 4)
                {
                    sr.color = new Color(0.1f, 0.2f, 1f, 1f);
                }

                // Purple
                if (i == 5)
                {
                    sr.color = new Color(0.7f, 0.1f, 1f, 1f);
                }
            }
        }

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

        // Rainbow
        if (colour == 7)
        {
            sr.color = new Color(0.3f, 0.3f, 0.3f, 1f);
        }

        if (dead == true)
        {
            animator.SetBool("dead", true);
        }
    }

    // Rainbow
    public void Rainbow(int seconds)
    {
        colour = 7;
        Invoke("Unrainbow", seconds);
    }

    public void Unrainbow()
    {
        colour = 0;
    }

    public void KillPlayer()
    {
        rb.gravityScale = 0;
        dead = true;
        animator.SetBool("jumping", false);
        animator.SetBool("falling", false);
        animator.SetBool("swimming", false);
        rb.velocity = Vector2.up * 2;
        rb.gravityScale = 0.5f;
        Invoke("Death", 0.5f);
    }

    // End the game if collision with an obstacle occurs
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Block(Clone)")
        {
            if (collision.gameObject.GetComponent<Block>().colour != colour && colour != 7 && dead == false)
            {
                KillPlayer();
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
            if (colour != 7)
            {
                colour = collision.gameObject.GetComponent<Paint>().colour;
            }
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "Rainbow")
        {
            Rainbow(5);
            Destroy(collision.gameObject);
        }
    }

    public void Death()
    {
        gameManager.GameOver();
    }
}

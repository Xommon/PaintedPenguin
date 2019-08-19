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
    public int timesTwoMode;
    public GameObject loadingBarPrefab;

    // Swipe controls
    public Vector3 swipeStartPosition;
    public Vector3 swipeEndPosition;
    public float swipeMinDistance = 1000;
    public string swipeDirection;

    void Start()
    {
        //Instantiate(CircleLoadingBar);
        timesTwoMode = 1;
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
            //transform.position = new Vector3(-0.33f, -0.075f, 0);
            rb.MovePosition(new Vector2(-0.33f, -0.075f));
            position = "jumping";
            rb.gravityScale = 0.5f;
            rb.velocity = new Vector2(0, 2.9f);
            animator.SetBool("jumping", true);
        }
    }

    public void Dive()
    {
        if (gameManager.paused == false && position == "walking")
        {
            //transform.position = new Vector3(-0.33f, -0.075f, 0);
            rb.MovePosition(new Vector2(-0.33f, -0.075f));
            position = "diving";
            rb.gravityScale = -0.5f;
            rb.velocity = new Vector2(0, -2.9f);
            animator.SetBool("swimming", true);
        }
    }

    private void Update()
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
    }

    void FixedUpdate()
    {
        // Loading bar position
        Vector3 barPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        loadingBarPrefab.transform.position = barPosition;

        if (position == "ready")
        {
            // Player is out of sight, ready to start
            rb.MovePosition(new Vector2(-1.0f, -0.075f));
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
            if (rb.position.x >= -0.33)
            {
                gameManager.on = true;
                position = ("walking");
                
            }
        }

        if (dead == false)
        {
            // Snap to ground if walking
            if (rb.position.y != -0.075 && position == "walking")
            {
                //transform.position = new Vector3(-0.33f, -0.075f, 0);
                rb.MovePosition(new Vector2(-0.33f, -0.075f));
                animator.SetBool("jumping", false);
                animator.SetBool("falling", false);
                animator.SetBool("swimming", false);
            }

            // Player starts walking if it falls to the ground or resurfaces from water
            if ((rb.position.y <= -0.010 && position == "falling") || ((rb.position.y >= -0.140) && position == "resurfacing"))
            {
                position = "walking";
                animator.SetBool("falling", false);
                animator.SetBool("swimming", false);

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
            sr.color = gameManager.White;
        }

        // Red
        if (colour == 1)
        {
            sr.color = gameManager.Red;
        }

        // Orange
        if (colour == 2)
        {
            sr.color = gameManager.Orange;
        }

        // Yellow
        if (colour == 3)
        {
            sr.color = gameManager.Yellow;
        }

        // Green
        if (colour == 4)
        {
            sr.color = gameManager.Green;
        }

        // Blue
        if (colour == 5)
        {
            sr.color = gameManager.Blue;
        }

        // Purple
        if (colour == 6)
        {
            sr.color = gameManager.Purple;
        }

        if (dead == true)
        {
            animator.SetBool("dead", true);
        }
    }

    // Rainbow
    public void Rainbow(float seconds)
    {
        colour = 7;
        GameObject loadingBar = Instantiate(loadingBarPrefab);
        RainbowCycle();
        Invoke("Unrainbow", seconds);
    }

    public void RainbowCycle()
    {
        if (colour == 7)
        {
        // If Purple
        if (sr.color == gameManager.Purple)
        {
            // Turn Red
            sr.color = gameManager.Red;
        }
        else

        // If Red
        if (sr.color == gameManager.Red)
        {
            // Turn Orange
            sr.color = gameManager.Orange;
        }
        else

        // If Orange
        if (sr.color == gameManager.Orange)
        {
            // Turn Yellow
            sr.color = gameManager.Yellow;
        }
        else

        // If Yellow
        if (sr.color == gameManager.Yellow)
        {
            // Turn Green
            sr.color = gameManager.Green;
        }
        else

        // If Green
        if (sr.color == gameManager.Green)
        {
            // Turn Blue
            sr.color = gameManager.Blue;
        }
        else

        // If Blue
        {
            // Turn Purple
            sr.color = gameManager.Purple;
        }

        Invoke("RainbowCycle", 0.15f);
        }
    }

    public void Unrainbow()
    {
        colour = 0;
    }

    // TimesTwo
    public void TimesTwoMode(float seconds)
    {
        timesTwoMode = 2;
        GameObject loadingBar = Instantiate(loadingBarPrefab);
        Invoke("UntimesTwoMode", seconds);
    }

    public void UntimesTwoMode()
    {
        timesTwoMode = 1;
    }

    public void KillPlayer()
    {
        
        StartCoroutine(gameManager.AddNewHighScore(gameManager.score));
        rb.gravityScale = 0;
        dead = true;
        animator.SetBool("jumping", false);
        animator.SetBool("falling", false);
        animator.SetBool("swimming", false);
        rb.velocity = Vector2.up * 2;
        rb.gravityScale = 0.5f;
        timesTwoMode = 1;
        Destroy(GameObject.FindGameObjectWithTag("LoadingBar"));
        Invoke("Death", 0.5f);
    }

    public void TimesUp()
    {
        colour = 0;
        timesTwoMode = 1;
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
                gameManager.score += (5 * timesTwoMode);
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
            if (colour != 7 && timesTwoMode == 1 && dead == false)
            {
                colour = 7;
                Rainbow(8.33f);
            }
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "TimesTwo")
        {
            if (timesTwoMode == 1 && colour != 7 && dead == false)
            {
                timesTwoMode = 2;
                TimesTwoMode(8.33f);
            }
            Destroy(collision.gameObject);
        }
    }

    public void Death()
    {
        gameManager.GameOver();
    }
}

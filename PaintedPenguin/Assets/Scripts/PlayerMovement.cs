using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;
    public GameManager gameManager;
    public string position;
    public bool dead;
    public int colour;
    public int timesTwoMode;
    public GameObject loadingBarPrefab;
    public int babyPuffins;
    public List<Vector2> playerPositions = new List<Vector2>();
    public List<GameObject> babies = new List<GameObject>();
    public GameObject testBaby;
    public GameObject floatingText;
    public GameObject touchGuide;
    public bool tutorial;
    public bool earlyJump = false;
    public bool earlyDive = false;
    public GameObject featherBurst;
    public ParticleSystem blockBurst;
    public ParticleSystem dustBurst;
    public ParticleSystem paintBurst;
    public int combo;
    public Language language;

    // Swipe controls
    public Vector3 swipeStartPosition;
    public Vector3 swipeEndPosition;
    public float swipeMinDistance;
    public string swipeDirection;

    void Start()
    {
        tutorial = true;
        swipeMinDistance = 10.0f;
        timesTwoMode = 1;
        dead = false;
        animator.SetBool("dead", false);
        rb = GetComponent<Rigidbody2D>();
        position = "ready";
        rb.gravityScale = 0;
    }

    public void Jump()
    {
        if (gameManager.paused == false && dead == false)
        {
            if (position == "walking")
            {
                rb.MovePosition(new Vector2(-0.33f, -0.075f));
                position = "jumping";
                rb.gravityScale = 0.5f;
                rb.velocity = new Vector2(0, 2.9f);
                animator.SetBool("jumping", true);
            }
            else
            {
                float margin = 0.7f;

                if (rb.position.y < (-0.075f + margin) && rb.position.y > -0.075f && position == "falling")
                {
                    earlyJump = true;
                    earlyDive = false;
                    Debug.Log("Early Jump from Jump");
                }
                else if (rb.position.y > (-0.075f - margin) && rb.position.y < -0.075f && position == "resurfacing")
                {
                    earlyJump = true;
                    earlyDive = false;
                    Debug.Log("Early Jump from Dive");
                }
            }
        }
    }

    public void Dive()
    {
        if (gameManager.paused == false && dead == false)
        {
            if (position == "walking")
            {
                rb.MovePosition(new Vector2(-0.33f, -0.075f));
                position = "diving";
                rb.gravityScale = -0.5f;
                rb.velocity = new Vector2(0, -2.9f);
                animator.SetBool("swimming", true);
            }
            else
            {
                float margin = 0.7f;

                if (rb.position.y < (-0.075f + margin) && rb.position.y > -0.075f && position == "falling")
                {
                    earlyJump = false;
                    earlyDive = true;
                    Debug.Log("Early Dive from Jump");
                }
                else if (rb.position.y > (-0.075f - margin) && rb.position.y < -0.075f && position == "resurfacing")
                {
                    earlyJump = false;
                    earlyDive = true;
                    Debug.Log("Early Dive from Dive");
                }
            }
        }
    }

    public void TutorialOff()
    {
        tutorial = false;
    }

    private void Update()
    {
        // Add positions to list
        if (gameManager.paused == false)
        {
            playerPositions.Add(rb.position);
            if (playerPositions.Count > 100)
            {
                playerPositions.RemoveAt(0);
            }
        }

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
                if (swipeStartPosition.y > swipeEndPosition.y && tutorial == false)
                {
                    swipeDirection = "down";
                    Dive();
                }

                if (swipeStartPosition.y < swipeEndPosition.y && tutorial == false)
                {
                    swipeDirection = "up";
                    Jump();
                }
            }

            if (colour == 7)
            {
                RainbowCycle();
            }
        }

        // Jump or swim only on the ground
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

        // Early Jump
        if (earlyDive == false && earlyJump == true && position == "walking")
        {
            Jump();
            earlyJump = false;
        }

        // Early Dive
        if (earlyJump == false && earlyDive == true && position == "walking")
        {
            Dive();
            earlyDive = false;
        }
    }

    public void SwitchGameOn()
    {
        gameManager.on = true;
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
                if (gameManager.canContinue == true)
                {
                    Invoke("SwitchGameOn", 2.5f);
                    Invoke("Jump", 0.5f);
                    Invoke("Dive", 2.2f);
                    Instantiate(touchGuide);
                    Invoke("TutorialOff", 3.0f);
                }
                position = ("walking");
            }
        }

        if (dead == false)
        {
            // Snap to ground if walking
            if (rb.position.y != -0.075 && position == "walking")
            {
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
            sr.color = gameManager.WhiteC;
        }

        // Red
        if (colour == 1)
        {
            sr.color = gameManager.RedC;
        }

        // Orange
        if (colour == 2)
        {
            sr.color = gameManager.OrangeC;
        }

        // Yellow
        if (colour == 3)
        {
            sr.color = gameManager.YellowC;
        }

        // Green
        if (colour == 4)
        {
            sr.color = gameManager.GreenC;
        }

        // Blue
        if (colour == 5)
        {
            sr.color = gameManager.BlueC;
        }

        // Purple
        if (colour == 6)
        {
            sr.color = gameManager.PurpleC;
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
        if (sr.color == gameManager.PurpleC)
        {
            // Turn Red
            sr.color = gameManager.RedC;
        }
        else

        // If Red
        if (sr.color == gameManager.RedC)
        {
            // Turn Orange
            sr.color = gameManager.OrangeC;
        }
        else

        // If Orange
        if (sr.color == gameManager.OrangeC)
        {
            // Turn Yellow
            sr.color = gameManager.YellowC;
        }
        else

        // If Yellow
        if (sr.color == gameManager.YellowC)
        {
            // Turn Green
            sr.color = gameManager.GreenC;
        }
        else

        // If Green
        if (sr.color == gameManager.GreenC)
        {
            // Turn Blue
            sr.color = gameManager.BlueC;
        }
        else

        // If Blue
        {
            // Turn Purple
            sr.color = gameManager.PurpleC;
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
        GameObject loadingBar = Instantiate(loadingBarPrefab);
        Invoke("UntimesTwoMode", seconds);
    }

    public void UntimesTwoMode()
    {
        timesTwoMode = 1;
    }

    public void KillPlayer()
    {
        Instantiate(featherBurst, gameObject.transform.position, Quaternion.identity, null);
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
        if (collision.transform.tag == "Block")
        {
            if (collision.gameObject.GetComponent<Block>().colour != colour && colour != 7 && dead == false)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                collision.gameObject.GetComponent<Block>().transform.rotation = Quaternion.identity;
                KillPlayer();
            }
            else if (collision.gameObject.GetComponent<Block>().hit == false && dead == false)
            {
                if (collision.transform.name == "BlockWithPaint(Clone)" && colour != 7 && dead == false)
                {
                    colour = collision.gameObject.GetComponent<Block>().colour2;
                }
                else if (collision.transform.name == "BlockWithRainbow(Clone)" && colour != 7 && timesTwoMode == 1 && dead == false)
                {
                    colour = 7;
                    Rainbow(8.33f);
                }
                else if (collision.transform.name == "BlockWithX3(Clone)" && colour != 7 && timesTwoMode == 1 && dead == false)
                {
                    timesTwoMode = 3;
                    TimesTwoMode(8.33f);
                }
                else if (collision.transform.name == "BlockWithBaby(Clone)" && dead == false && babyPuffins < 3)
                {
                    Instantiate(babies[0]);
                    babies.RemoveAt(0);
                    babyPuffins++;
                }

                ParticleSystem ps = Instantiate(blockBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ParticleSystem ps2 = Instantiate(dustBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ps.startColor = collision.gameObject.GetComponent<Block>().sr.color;
                Destroy(ps.gameObject, ps.startLifetime);
                Destroy(ps2.gameObject, ps2.startLifetime);

                GameObject floatText = Instantiate(floatingText, collision.transform.position, Quaternion.identity);
                floatText.GetComponent<TextMeshPro>().color = collision.gameObject.GetComponent<Block>().sr.color;
                if (gameManager.playerLanguage != "Latin")
                {
                    floatText.GetComponent<TextMeshPro>().text = (5 * timesTwoMode).ToString();
                }
                else
                {
                    floatText.GetComponent<TextMeshPro>().text = gameManager.language.toRoman(5 * timesTwoMode);
                }
                floatText.GetComponent<FloatingText>().verticalSpeed = 0.5f;
                floatText.GetComponent<FloatingText>().horizontalSpeed = 0f;
                gameManager.score += (5 * timesTwoMode);
                collision.gameObject.GetComponent<Block>().hit = true;
                Destroy(collision.gameObject);
                Destroy(floatText, 1.0f);
                
                if (combo == collision.gameObject.GetComponent<Block>().wave)
                {
                    GameObject floatText2 = Instantiate(floatingText, collision.transform.position, Quaternion.identity);
                    floatText2.GetComponent<FloatingText>().verticalSpeed = 0f;
                    floatText2.GetComponent<FloatingText>().horizontalSpeed = 0f;
                    floatText2.GetComponent<TextMeshPro>().color = collision.gameObject.GetComponent<Block>().sr.color;
                    floatText2.GetComponent<TextMeshPro>().text = "combo";
                    Destroy(floatText2, 1.0f);

                    GameObject floatText3 = Instantiate(floatingText, collision.transform.position, Quaternion.identity);
                    floatText3.GetComponent<FloatingText>().verticalSpeed = 0.25f;
                    floatText3.GetComponent<FloatingText>().horizontalSpeed = 0.5f;
                    floatText3.GetComponent<TextMeshPro>().color = collision.gameObject.GetComponent<Block>().sr.color;
                    floatText3.GetComponent<TextMeshPro>().text = (5 * (1 + babyPuffins)).ToString();
                    gameManager.score += (5 * (1 + babyPuffins));
                    Destroy(floatText3, 1.0f);
                }
                else
                {
                    combo = collision.gameObject.GetComponent<Block>().wave;
                }
            }
        }

        if (collision.transform.tag == "SpikeBall")
        {
            KillPlayer();
        }

        if (collision.transform.tag == "Paint")
        {
            ParticleSystem ps3 = Instantiate(paintBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
            ps3.startColor = collision.gameObject.GetComponent<Paint>().sr.color;
            Destroy(ps3.gameObject, ps3.startLifetime);

            if (colour != 7)
            {
                colour = collision.gameObject.GetComponent<Paint>().colour;
            }

            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "Rainbow")
        {
            ParticleSystem ps3 = Instantiate(paintBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
            ps3.startColor = sr.color;
            Destroy(ps3.gameObject, ps3.startLifetime);

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

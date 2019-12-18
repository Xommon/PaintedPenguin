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
    public List<string> playerPositions2 = new List<string>();
    public List<GameObject> babies = new List<GameObject>();
    public GameObject floatingText;
    public GameObject touchGuide;
    public bool tutorial;
    public bool earlyJump = false;
    public bool earlyDive = false;
    public GameObject featherBurst;
    public ParticleSystem blockBurst;
    public ParticleSystem dustBurst;
    public ParticleSystem paintBurst;
    public ParticleSystem splashParticles;
    public GameObject blockPop;
    public int combo;
    public Language language;
    public TMP_FontAsset apu_title;
    public TMP_FontAsset roboto;
    public bool flashing;
    public bool magnet;
    public int count;
    public float walkingPosition;
    public CameraShake cameraShake;
    public int comboStreak;
    public AudioClip playBlockNote;
    public int soundToPlay;

    // Swipe controls
    public Vector3 swipeStartPosition;
    public Vector3 swipeEndPosition;
    public float swipeMinDistance;
    public string swipeDirection;

    void Start()
    {
        flashing = false;
        tutorial = true;
        swipeMinDistance = 10.0f;
        timesTwoMode = 1;
        magnet = false;
        colour = 0;
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
                rb.MovePosition(new Vector2(walkingPosition, -0.075f));
                position = "jumping";
                rb.gravityScale = 0.5f;
                rb.velocity = new Vector2(0, 2.9f);
                animator.SetBool("jumping", true);
                FindObjectOfType<AudioManager>().Play("jump");
            }
            else
            {
                float margin = 0.7f;

                if (rb.position.y < (-0.075f + margin) && rb.position.y > -0.075f && position == "falling")
                {
                    earlyJump = true;
                    earlyDive = false;
                }
                else if (rb.position.y > (-0.075f - margin) && rb.position.y < -0.075f && position == "resurfacing")
                {
                    earlyJump = true;
                    earlyDive = false;
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
                rb.MovePosition(new Vector2(walkingPosition, -0.075f));
                position = "diving";
                rb.gravityScale = -0.5f;
                rb.velocity = new Vector2(0, -2.9f);
                animator.SetBool("swimming", true);
                FindObjectOfType<AudioManager>().Play("splash");
            }
            else
            {
                float margin = 0.7f;

                if (rb.position.y < (-0.075f + margin) && rb.position.y > -0.075f && position == "falling")
                {
                    earlyJump = false;
                    earlyDive = true;
                }
                else if (rb.position.y > (-0.075f - margin) && rb.position.y < -0.075f && position == "resurfacing")
                {
                    earlyJump = false;
                    earlyDive = true;
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
        if (flashing == true)
        {
            count += int.Parse((5 * Time.deltaTime).ToString().Substring(0, 1));

            if (count % 2 == 0)
            {
                FlashOn();
            }
            else if (count % 2 == 1)
            {
                FlashOff();
            }
        }
        else
        {
            count = 0;
        }

        if (splashParticles.transform.position.x == 0 & transform.position.y < -0.14 && transform.position.y > -0.2 && dead == false)
        {
            // Different spawns depending on if player is resurfacing or diving
            ParticleSystem ps4 = Instantiate(splashParticles, transform.position, Quaternion.identity) as ParticleSystem;
            Destroy(ps4.gameObject, ps4.startLifetime);
        } 

        // Add positions to list
        if (gameManager.paused == false)
        {
            playerPositions.Add(rb.position);
            if (dead == false)
            {
                playerPositions2.Add(position);
            }
            else
            {
                playerPositions2.Add("dead");
            }
            if (playerPositions.Count > 100)
            {
                playerPositions.RemoveAt(0);
                playerPositions2.RemoveAt(0);
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
        if (gameManager.canContinue == true)
        {
            gameManager.on = true;
        }
        else
        {
            Invoke("SwitchGameOnTwo", 2.0f);
        }
    }

    public void SwitchGameOnTwo()
    {
        gameManager.on = true;
    }

    public void StartWalking()
    {
        position = "starting";
        rb.velocity = transform.right;
        gameManager.tutorialWindow.SetActive(false);
        animator.SetBool("dead", false);
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
            StartWalking();

            // Start game if player is in position, start the game
            if (rb.position.x >= (walkingPosition - 0.03f))
            {
                if (gameManager.canContinue == true && gameManager.playerTutorialEnabled == true)
                {
                    Invoke("SwitchGameOn", 3.5f);
                    Invoke("Jump", 0.5f);
                    Invoke("Dive", 2.2f);
                    Instantiate(touchGuide);
                    Invoke("TutorialOff", 3.0f);
                }
                else if (gameManager.canContinue == true || gameManager.playerTutorialEnabled == false)
                {
                    tutorial = false;
                    SwitchGameOn();
                }

                position = ("walking");
            }
        }

        if (dead == false)
        {
            // Snap to ground if walking
            if (rb.position.y != -0.075 && position == "walking")
            {
                rb.MovePosition(new Vector2(walkingPosition, -0.075f));
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
    public void Rainbow()
    {
        colour = 7;
        if (FindObjectOfType<LoadingBar>() == null)
        {
            GameObject loadingBar = Instantiate(loadingBarPrefab);
        }
        RainbowCycle();
    }

    // Magnet
    public void Magnet()
    {
        magnet = true;
        if (FindObjectOfType<LoadingBar>() == null)
        {
            GameObject loadingBar = Instantiate(loadingBarPrefab);
        }
    }

    public void FlashOn()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1.0f);
    }

    public void FlashOff()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.0f);
    }

    public void ColourFlashWarning()
    {
        if (colour == 7 && flashing == false)
        {
            count = 0;
            flashing = true;
        }
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

    // TimesTwo
    public void TimesTwoMode()
    {
        if (FindObjectOfType<LoadingBar>() == null)
        {
            GameObject loadingBar = Instantiate(loadingBarPrefab);
        }
    }

    public void CreateBaby()
    {
        Instantiate(babies[0]);
        babies.RemoveAt(0);
        babyPuffins++;
        FindObjectOfType<AudioManager>().Play("peep");
    }

    public void KillPlayer()
    {
        FindObjectOfType<AudioManager>().Play("peep");
        FindObjectOfType<AudioManager>().Pause("splash");
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

    // End the game if collision with an obstacle occurs
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Block")
        {
            if (collision.transform.tag == "Spikeball")
            {
                KillPlayer();
            }

            if (collision.transform.tag == "Wave")
            {
                collision.gameObject.GetComponent<Water>().animator.SetBool("splash", true);
            }

            if (collision.gameObject.GetComponent<Block>().colour != colour && colour != 7 && dead == false)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                collision.gameObject.GetComponent<Block>().transform.rotation = Quaternion.identity;
                KillPlayer();
            }
            else if (collision.gameObject.GetComponent<Block>().hit == false && dead == false)
            {
                if (collision.transform.name == "BlockWithPaint(Clone)" && colour != 7 && dead == false && collision.gameObject.GetComponent<Block>().contentsActive == true)
                {
                    ParticleSystem ps3 = Instantiate(paintBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                    ps3.startColor = sr.color;
                    Destroy(ps3.gameObject, ps3.startLifetime);
                    colour = collision.gameObject.GetComponent<Block>().colour2;

                    if (soundToPlay == null || soundToPlay == 0)
                    {
                        soundToPlay = Random.Range(1, 4);
                        FindObjectOfType<AudioManager>().Play("bubble" + soundToPlay.ToString());
                    }
                    else
                    {
                        if (soundToPlay == 1)
                        {
                            if (gameManager.PercentChance(50))
                            {
                                FindObjectOfType<AudioManager>().Play("bubble2");
                            }
                            else
                            {
                                FindObjectOfType<AudioManager>().Play("bubble3");
                            }

                            if (gameManager.PercentChance(50))
                            {
                                soundToPlay = 2;
                            }
                            else
                            {
                                soundToPlay = 3;
                            }
                        }
                        else if (soundToPlay == 2)
                        {
                            if (gameManager.PercentChance(50))
                            {
                                FindObjectOfType<AudioManager>().Play("bubble1");
                            }
                            else
                            {
                                FindObjectOfType<AudioManager>().Play("bubble3");
                            }

                            if (gameManager.PercentChance(50))
                            {
                                soundToPlay = 1;
                            }
                            else
                            {
                                soundToPlay = 3;
                            }
                        }
                        else if (soundToPlay == 3)
                        {
                            if (gameManager.PercentChance(50))
                            {
                                FindObjectOfType<AudioManager>().Play("bubble2");
                            }
                            else
                            {
                                FindObjectOfType<AudioManager>().Play("bubble1");
                            }

                            if (gameManager.PercentChance(50))
                            {
                                soundToPlay = 1;
                            }
                            else
                            {
                                soundToPlay = 2;
                            }
                        }
                    }
                }
                else if (collision.transform.name == "BlockWithRainbow" || collision.transform.name == "BlockWithRainbow(Clone)" && colour != 7 && dead == false && collision.gameObject.GetComponent<Block>().contentsActive == true)
                {
                    colour = 7;
                    Rainbow();
                    FindObjectOfType<AudioManager>().Play("powerup");
                }
                else if ((collision.transform.name == "BlockWithX3" || collision.transform.name == "BlockWithX3(Clone)") && dead == false && collision.gameObject.GetComponent<Block>().contentsActive == true)
                {
                    timesTwoMode *= 3;
                    TimesTwoMode();
                    FindObjectOfType<AudioManager>().Play("powerup");
                }
                else if ((collision.transform.name == "BlockWithBaby" || collision.transform.name == "BlockWithBaby(Clone)") && dead == false && babyPuffins < 3 && collision.gameObject.GetComponent<Block>().contentsActive == true)
                {
                    CreateBaby();
                }
                else if ((collision.transform.name == "BlockWithMagnet" || collision.transform.name == "BlockWithMagnet(Clone)") && dead == false && collision.gameObject.GetComponent<Block>().contentsActive == true)
                {
                    Magnet();
                    FindObjectOfType<AudioManager>().Play("powerup");
                }

                if (colour == 7)
                {
                    comboStreak++;
                }

                ParticleSystem ps = Instantiate(blockBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ParticleSystem ps2 = Instantiate(dustBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                Instantiate(blockPop, collision.transform.position, Quaternion.identity);
                ps.startColor = collision.gameObject.GetComponent<Block>().sr.color;
                Destroy(ps.gameObject, ps.startLifetime);
                Destroy(ps2.gameObject, ps2.startLifetime);
                StartCoroutine(cameraShake.Shake(0.24f, 0.65f));
                FindObjectOfType<AudioManager>().GetComponent<AudioSource>().pitch = 1 + (comboStreak / 4);
                //FindObjectOfType<AudioManager>().Play("blocknote");
                FindObjectOfType<AudioManager>().Play("blockdestroy");

                GameObject floatText = Instantiate(floatingText, collision.transform.position, Quaternion.identity);
                floatText.GetComponent<TextMeshPro>().color = collision.gameObject.GetComponent<Block>().sr.color;
                floatText.GetComponent<TextMeshPro>().font = apu_title;
                if (gameManager.playerLanguage != "Latin")
                {
                    floatText.GetComponent<TextMeshPro>().text = (10 * timesTwoMode).ToString();
                }
                else
                {
                    floatText.GetComponent<TextMeshPro>().text = gameManager.ToRoman(5 * timesTwoMode);
                }
                floatText.GetComponent<FloatingText>().verticalSpeed = 0.5f;
                floatText.GetComponent<FloatingText>().horizontalSpeed = 0f;
                gameManager.score += (10 * timesTwoMode);
                collision.gameObject.GetComponent<Block>().hit = true;
                Destroy(collision.gameObject);
                Destroy(floatText, 1.0f);
                
                if (combo == collision.gameObject.GetComponent<Block>().wave)
                {
                    GameObject floatText2 = Instantiate(floatingText, collision.transform.position, Quaternion.identity);
                    floatText2.GetComponent<FloatingText>().verticalSpeed = 0f;
                    floatText2.GetComponent<FloatingText>().horizontalSpeed = 0f;
                    floatText2.GetComponent<TextMeshPro>().color = collision.gameObject.GetComponent<Block>().sr.color;
                    floatText2.GetComponent<TextMeshPro>().text = language.Combo;
                    floatText2.GetComponent<TextMeshPro>().font = language.cjkFont;
                    Destroy(floatText2, 1.0f);

                    GameObject floatText3 = Instantiate(floatingText, collision.transform.position, Quaternion.identity);
                    floatText3.GetComponent<FloatingText>().verticalSpeed = 0.25f;
                    floatText3.GetComponent<FloatingText>().horizontalSpeed = 0.5f;
                    floatText3.GetComponent<TextMeshPro>().color = collision.gameObject.GetComponent<Block>().sr.color;
                    if (gameManager.playerLanguage == "Latin")
                    {
                        floatText3.GetComponent<TextMeshPro>().text = gameManager.ToRoman((5 * (1 + babyPuffins)));
                    }
                    else
                    {
                        floatText3.GetComponent<TextMeshPro>().text = (10 * (1 + babyPuffins * 10)).ToString();
                    }
                    floatText3.GetComponent<TextMeshPro>().font = apu_title;
                    gameManager.score += (10 * (1 + babyPuffins));
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
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.transform.rotation = Quaternion.identity;
            KillPlayer();
        }

        if (collision.transform.tag == "Fist")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            KillPlayer();
        }

        if (collision.transform.tag == "Paint")
        {
            ParticleSystem ps3 = Instantiate(paintBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
            ps3.startColor = collision.gameObject.GetComponent<Paint>().sr.color;
            Destroy(ps3.gameObject, ps3.startLifetime);
            if (soundToPlay == null || soundToPlay == 0)
            {
                soundToPlay = Random.Range(1, 4);
                FindObjectOfType<AudioManager>().Play("bubble" + soundToPlay.ToString());
            }
            else
            {
                if (soundToPlay == 1)
                {
                    if (gameManager.PercentChance(50)) {
                        FindObjectOfType<AudioManager>().Play("bubble2");
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Play("bubble3");
                    }

                    if (gameManager.PercentChance(50))
                    {
                        soundToPlay = 2;
                    }
                    else
                    {
                        soundToPlay = 3;
                    }
                }
                else if (soundToPlay == 2)
                {
                    if (gameManager.PercentChance(50))
                    {
                        FindObjectOfType<AudioManager>().Play("bubble1");
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Play("bubble3");
                    }

                    if (gameManager.PercentChance(50))
                    {
                        soundToPlay = 1;
                    }
                    else
                    {
                        soundToPlay = 3;
                    }
                }
                else if (soundToPlay == 3)
                {
                    if (gameManager.PercentChance(50))
                    {
                        FindObjectOfType<AudioManager>().Play("bubble2");
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Play("bubble1");
                    }

                    if (gameManager.PercentChance(50))
                    {
                        soundToPlay = 1;
                    }
                    else
                    {
                        soundToPlay = 2;
                    }
                }
            }

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
            FindObjectOfType<AudioManager>().Play("bubble");

            if (colour != 7 && dead == false)
            {
                colour = 7;
                Rainbow();
                FindObjectOfType<AudioManager>().Play("powerup");
            }

            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "TimesTwo")
        {
            if (dead == false)
            {
                Instantiate(blockPop, collision.transform.position, Quaternion.identity);
                timesTwoMode *= 2;
                TimesTwoMode();
                FindObjectOfType<AudioManager>().Play("powerup");
            }

            Destroy(collision.gameObject);
        }
    }

    public void Death()
    {
        gameManager.GameOver();
    }
}

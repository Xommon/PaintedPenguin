using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Menu components
    public GameObject gameOverCanvas;
    public GameObject continueButtonUI;
    public GameObject mainMenuUI;
    public GameObject gameUI;
    public GameObject adController;

    // Game components
    public bool on;
    public int score;
    public float maxTime2 = 1;
    public PlayerMovement player;
    public bool canContinue;

    // Obstacle creation
    public float maxTime = 1;
    private float timer = 0;
    public GameObject block;
    public GameObject paint;
    float place;
    float place2;
    float place3;
    public float obstacleSpeed;

    void SpawnBlock()
    {
        if (timer > maxTime)
        {
            // Create the two blocks
            GameObject newblock = Instantiate(block);
            GameObject newblock2 = Instantiate(block);
            GameObject newpaint = Instantiate(paint);

            // Randow draw to figure out placement of first block
            int roll = Random.Range(1, 4); // 1, 2 or 3
            if (roll == 1)
            {
                // Ground
                place = -0.1f;
            }
            if (roll == 2)
            {
                // Air
                place = 0.7f;
            }
            if (roll == 3)
            {
                // Water
                place = -0.9f;
            }

            // Place second block randomly where ever the first block is not
            int roll2 = Random.Range(1, 4); // 1, 2 or 3
            // If the first block is on the ground
            if (roll == 1)
            {
                if (roll2 == 1)
                {
                    // Air
                    place2 = 0.7f;
                }
                if (roll2 == 2)
                {
                    // Water
                    place2 = -0.9f;
                }
                if (roll2 == 3)
                {
                    // Out of the frame
                    place2 = 2f;
                }
            }

            // If the first block is in the air
            if (roll == 2)
            {
                if (roll2 == 1)
                {
                    // Ground
                    place2 = -0.1f;
                }
                if (roll2 == 2)
                {
                    // Water
                    place2 = -0.9f;
                }
                if (roll2 == 3)
                {
                    // Out of the frame
                    place2 = 2f;
                }
            }

            // If the first block is in the water
            if (roll == 3)
            {
                if (roll2 == 1)
                {
                    // Ground
                    place2 = -0.1f;
                }
                if (roll2 == 2)
                {
                    // Air
                    place2 = 0.7f;
                }
                if (roll2 == 3)
                {
                    // Out of the frame
                    place2 = 2f;
                }
            }

            // Place paint where ever the last space is
            if (score == 0 || score % 10 == 0)
            {
                if (roll == 1) // No space on ground
                {
                    if (roll2 == 1) // No space in air
                    {
                        // Water
                        place3 = -0.9f;
                    }

                    if (roll2 == 2) // No space in water
                    {
                        // Air
                        place3 = 0.7f;
                    }

                    if (roll2 == 3)
                    {
                        // Out of the frame
                        place3 = 2f;
                    }
                }

                if (roll == 2) // No space in air
                {
                    if (roll2 == 1) // No space on ground
                    {
                        // Water
                        place3 = -0.9f;
                    }

                    if (roll2 == 2) // No space in water
                    {
                        // Ground
                        place3 = -0.1f;
                    }

                    if (roll2 == 3)
                    {
                        // Out of the frame
                        place3 = 2f;
                    }
                }

                if (roll == 3) // No space in water
                {
                    if (roll2 == 1) // No space on ground
                    {
                        // Air
                        place3 = 0.7f;
                    }

                    if (roll2 == 2) // No space in air
                    {
                        // Ground
                        place3 = -0.1f;
                    }

                    if (roll2 == 3)
                    {
                        // Out of the frame
                        place3 = 2f;
                    }
                }
            }

            // Position the blocks
            newblock.transform.position = transform.position + new Vector3(1, place, 0);
            newblock2.transform.position = transform.position + new Vector3(1, place2, 0);
            paint.transform.position = transform.position + new Vector3(1, place3, 0);

            // Increase score every second
            score += 1;

            // Destroy the blocks once the timer runs out
            Destroy(newblock, 2);
            Destroy(newblock2, 2);
            Destroy(newpaint, 2);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void Start()
    {
        mainMenuUI.SetActive(true);
        canContinue = true;
        Time.timeScale = 1;
        score = 0;
    }

    // Start Button pressed
    public void StartGame()
    {
        player.position = "starting";
        mainMenuUI.SetActive(false);
        gameUI.SetActive(true);
    }

    // Score Button pressed
    public void ScoreButton()
    {
        // ONLINE HIGH SCORE LIST
    }

    public void Update()
    {
        // Menus
        if (gameOverCanvas.activeInHierarchy == true)
        {
            //Time.timeScale -= 0.05f;
        }

        // Obstacles
        if (on == true && player.dead == false)
        {
            SpawnBlock();
        }

        // *** FOR DESKTOP TESTING ONLY ***
        if (Input.GetKeyDown("return"))
        {
            if (mainMenuUI.activeInHierarchy == true)
            {
                StartGame();
            }

            if (gameOverCanvas.activeInHierarchy == true)
            {
                if (continueButtonUI.activeInHierarchy == true)
                {
                    ContinueButton();
                } else
                {
                    RestartGame();
                }
            }

        }
    }

    //Display game over overlay when the player dies
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        if (canContinue == false)
        {
            continueButtonUI.SetActive(false);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ContinueButton()
    {
        Time.timeScale = 1f;
        player.dead = false;
        gameOverCanvas.SetActive(false);
        player.position = "starting";
        canContinue = false;
    }
}

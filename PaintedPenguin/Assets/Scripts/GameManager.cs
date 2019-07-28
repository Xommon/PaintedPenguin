using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Menu components
    public GameObject gameOverCanvas;
    public GameObject mainMenuUI;
    public GameObject gameUI;

    // Game components
    public bool on;
    public int score;
    public PlayerMovement player;

    // Obstacle creation
    public float maxTime = 1;
    private float timer = 0;
    public GameObject block;
    public GameObject paint;
    float place;
    float place2;
    bool pass;

    void SpawnBlock()
    {
        if (timer > maxTime)
        {
            // Create the two blocks
            GameObject newblock = Instantiate(block);
            GameObject newblock2 = Instantiate(block);
            bool pass = false;

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
                    // Out of frame
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
                    // Out of frame
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
                    // Out of frame
                    place2 = 2f;
                }
            }

            // Position the blocks
            newblock.transform.position = transform.position + new Vector3(1, place, 0);
            newblock2.transform.position = transform.position + new Vector3(1, place2, 0);

            // If the block passes by the player without being hit, then the player gets a point
            score += 1;

            // Destroy the blocks once the timer runs out
            Destroy(newblock, 2);
            Destroy(newblock2, 2);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void Start()
    {
        mainMenuUI.SetActive(true);
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

    }

    // Replay Button pressed
    public void ReplayButton()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().SampleScene);
    }

    public void Update()
    {
        // Menus
        if (gameOverCanvas.activeInHierarchy == true)
        {
            //Time.timeScale -= 0.05f;
        }

        // Obstacles
        if (on == true)
        {
            SpawnBlock();
        }
    }

    //Display game over overlay when the player dies
    public void GameOver()
    {
        Time.timeScale = 0.5f;
        //new WaitForSeconds(2);
        gameOverCanvas.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}

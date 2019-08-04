using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GameManager : MonoBehaviour
{
    // Menu components
    public GameObject gameOverCanvas;
    public GameObject continueButtonUI;
    public GameObject mainMenuUI;
    public GameObject gameUI;
    public GameObject pauseUI;
    public bool paused = false;
    public GameObject pauseButton;

    // Game components
    public bool on;
    public int score;
    public float maxTime2 = 1;
    public PlayerMovement player;
    public bool canContinue;
    public static int highScore;

    // High scores
    // http://dreamlo.com/lb/cQ87T8a7BUGRQmQNMDB6iwWUTDoSubyUOyfJ9_43b3_g

    const string privateCode = "cQ87T8a7BUGRQmQNMDB6iwWUTDoSubyUOyfJ9_43b3_g";
    const string publicCode = "5d43646f76827f1758cfaa7c";
    const string webURL = "dreamlo.com/lb/";

    // Obstacle creation
    public float maxTime = 1;
    private float timer = 0;
    public GameObject block;
    public GameObject paint;
    public GameObject rainbow;
    float place;
    float place2;
    public float obstacleSpeed;
    public List<float> obstaclePositions = new List<float>();

    public bool PercentChance(int percent)
    {
        int selection = Random.Range(0, 101);
        if (selection <= percent)
        {
            return true;
        } else
        {
            return false;
        }
    }

    void SpawnBlock()
    {
        if (timer > maxTime)
        {
            // Create a list of possible positions
            obstaclePositions.Clear();
            obstaclePositions.Add(-0.1f);
            obstaclePositions.Add(0.7f);
            obstaclePositions.Add(-0.9f);

            // Place first block
            GameObject newblock = Instantiate(block);
            place = obstaclePositions[(Random.Range(0, 3))]; // 0, 1 or 2
            newblock.transform.position = transform.position + new Vector3(1, place, 0);
            obstaclePositions.Remove(place);

            // Place second block
            GameObject newblock2 = Instantiate(block);
            place = obstaclePositions[(Random.Range(0, 2))]; // 0 or 1
            newblock2.transform.position = transform.position + new Vector3(1, place, 0);
            obstaclePositions.Remove(place);

            // Place paint
            if (PercentChance(25))
            {
                GameObject newpaint = Instantiate(paint);
                newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
            } else
            {
                if (PercentChance(1))
                {
                    GameObject newpaint = Instantiate(rainbow);
                    newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                }
            }

            // Increase score every second
            score += 1;
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    // Adding high scores
    IEnumerator AddNewHighScore(string username, int score)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    public void Start()
    {
        mainMenuUI.SetActive(true);
        canContinue = true;
        Time.timeScale = 1;
        score = 0;
    }

    public void Pause()
    {
        // Pause
        if (paused == false)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
        else
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
            paused = false;
        }
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
        // Obstacles
        if (on == true && player.dead == false)
        {
            SpawnBlock();
        }

        if (player.dead == true)
        {
            pauseButton.SetActive(false);
        } else
        {
            pauseButton.SetActive(true);
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

        if (Input.GetKeyDown("space"))
        {
            Pause();
        }
    }

    //Display game over overlay and upload high score when the player dies
    public void GameOver()
    {
        StartCoroutine(AddNewHighScore("Test" + Random.Range(0, 100), score));
        gameOverCanvas.SetActive(true);
        if (canContinue == false)
        {
            continueButtonUI.SetActive(false);
        }
    }

    public void RestartGame()
    {
        gameUI.SetActive(false);
        if (score > highScore)
        {
            highScore = score;
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void ClearObstacles()
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Block");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }

        obstacles = GameObject.FindGameObjectsWithTag("Paint");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }

        obstacles = GameObject.FindGameObjectsWithTag("Rainbow");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    public void ContinueButton()
    {
        ClearObstacles();
        canContinue = false;
        Time.timeScale = 1f;
        player.dead = false;
        gameOverCanvas.SetActive(false);
        player.position = "starting";
    }
}

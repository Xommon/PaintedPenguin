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
    public Text helloUsernameUI;
    public bool paused = false;
    public GameObject pauseButton;
    public Text warning;

    // Game components
    public bool on;
    public int score;
    public float maxTime2 = 1;
    public PlayerMovement player;
    public bool canContinue;

    // High scores
    // http://dreamlo.com/lb/cQ87T8a7BUGRQmQNMDB6iwWUTDoSubyUOyfJ9_43b3_g

    const string privateCode = "cQ87T8a7BUGRQmQNMDB6iwWUTDoSubyUOyfJ9_43b3_g";
    const string publicCode = "5d43646f76827f1758cfaa7c";
    const string webURL = "dreamlo.com/lb/";
    public Highscore[] highScoresList;
    public GameObject highScoreTableUI;
    public Text tableScoreUI;
    public Text tableUsernameUI;
    public Text tablePlaceUI;
    public GameObject usernameInputUI;
    public static string playerUsername = "";

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

    public bool PercentChance(float percent)
    {
        float selection = Random.Range(0.0f, 101.0f);
        Debug.Log("Selection: " + selection);
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
                if (PercentChance(0.5f))
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
    IEnumerator AddNewHighScore(int score)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(playerUsername) + "/" + score);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error Uploading: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownloadHighScoresFromDatabase");
    }

    IEnumerator DownloadHighScoresFromDatabase()
    {
        UnityWebRequest uwr = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error Downloading: " + uwr.error);
        }
        else
        {
            FormatHighScores(uwr.downloadHandler.text);
            OnHighscoresDownloaded(highScoresList);
        }
    }


    void FormatHighScores(string textStream)
    {
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highScoresList = new Highscore[entries.Length];
        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highScoresList[i] = new Highscore(username, score);
        }
    }

    public struct Highscore
    {
        public string username;
        public int score;

        public Highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }

    public void GetUsername(string name)
    {
        playerUsername = name;
    }

    // Code for start of script
    public void Start()
    {
        // Enter username at the beginning of the game
        if (playerUsername == "")
        {
            usernameInputUI.SetActive(true);
            mainMenuUI.SetActive(false);
        } else // If the player's username has already been set
        {
            usernameInputUI.SetActive(false);
            mainMenuUI.SetActive(true);
            Time.timeScale = 1;
        }
        canContinue = true;
        score = 0;
        DownloadHighScores();

        // Displaying high scores
        //for (int i = 0; i < highscoreText.Length; i++)
        {
            //highscoreText[i].text = i + 1 + ". Fetching ...";
        }

        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        // Clear all display text
        tablePlaceUI.text = "";
        tableUsernameUI.text = "";
        tableScoreUI.text = "";
        
        // Populate the score table
        for (int i = 0; i <= 99; i++)
        {
            // Score
            tableScoreUI.text += highscoreList[i].score + "\n";

            // Username
            tableUsernameUI.text += highscoreList[i].username + "\n";

            if (i < 9)
            {
                tablePlaceUI.text += "00";
            }

            if (i > 8 && i < 99)
            {
                tablePlaceUI.text += "0";
            }
            // Place
            tablePlaceUI.text += i + 1 + ": \n";
        }
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            DownloadHighScores();
            yield return new WaitForSeconds(30);
        }
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
        mainMenuUI.SetActive(false);
        highScoreTableUI.SetActive(true);
    }

    public void xButtonScore()
    {
        highScoreTableUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void OKButton()
    {
        if (usernameInputUI.activeInHierarchy == true)
        {
            if (playerUsername.Contains(" ") || playerUsername.Contains("*"))
            {
                warning.text = "Cannot contain * or spaces.";
            }
            else if (playerUsername.Length < 1 || playerUsername.Length > 12)
            {
                warning.text = "Must be between 1 and 12 characters.";
            }
            else
            {
                usernameInputUI.SetActive(false);
                mainMenuUI.SetActive(true);
            }
        }
    }

    public void Update()
    {
        // Hello, Username!
        helloUsernameUI.text = "Hello, " + playerUsername + "!";

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

            // Set username
            OKButton();
        }

        if (Input.GetKeyDown("space") && gameUI.activeInHierarchy == true)
        {
            Pause();
        }

        if (Input.GetKeyDown("escape"))
        {
            xButtonScore();
        }
    }

    //Display game over overlay and upload high score when the player dies
    public void GameOver()
    {
        StartCoroutine(AddNewHighScore(score));
        gameOverCanvas.SetActive(true);
        if (canContinue == false)
        {
            continueButtonUI.SetActive(false);
        }
    }

    public void RestartGame()
    {
        gameUI.SetActive(false);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

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
    public int colourblindMode;
    public Image redImage;
    public Image orangeImage;
    public Image yellowImage;
    public Image greenImage;
    public Image blueImage;
    public Image purpleImage;

    // Location
    public string playerRegion;
    public string playerCountry;

    // Colours
    //[System.NonSerialized]
    public Color WhiteC;
    //[System.NonSerialized]
    public Color RedC;
    //[System.NonSerialized]
    public Color OrangeC;
    //[System.NonSerialized]
    public Color YellowC;
    //[System.NonSerialized]
    public Color GreenC;
    //[System.NonSerialized]
    public Color BlueC;
    //[System.NonSerialized]
    public Color PurpleC;

    // Game components
    public bool on;
    public int score;
    public PlayerMovement player;
    public bool canContinue;
    public Image uploadScoreUI;
    public Sprite loadingSprite;
    public Sprite uploadedSprite;
    public Sprite errorSprite;

    // High scores
    const string privateCode = "cQ87T8a7BUGRQmQNMDB6iwWUTDoSubyUOyfJ9_43b3_g";
    const string publicCode = "5d43646f76827f1758cfaa7c";
    const string webURL = "dreamlo.com/lb/";
    public Highscore[] highScoresList;
    public GameObject highScoreTableUI;
    public Text tableScoreUI;
    public Text tableUsernameUI;
    public Text tablePlaceUI;
    public GameObject tableCountryUI;
    public Image tableFlagUI;
    public Sprite defaultFlag;
    public GameObject usernameInputUI;
    public string playerUsername;
    public string playerLanguage;

    // Languages
    public Language language;
    public GameObject languageTableUI;

    public GameObject gameTitleText;
    public Text startButtonText;
    public Text scoreButtonText;
    public Text helloUsernameText;

    public Text gameOverText;
    public Text replayButtonText;
    public Text continueButtonText;

    public Text scoreText;

    public Text pauseText;

    public Text highScoresText;

    public Text nameFillInText;
    public Text okButtonText;
    public Text warningBoxText;

    // Obstacle creation
    public float maxTime = 1;
    private float timer = 0;
    public GameObject block;
    public GameObject paint;
    public GameObject rainbow;
    public GameObject timesTwo;
    float place;
    public List<float> obstaclePositions = new List<float>();

    public bool PercentChance(float percent)
    {
        float selection = Random.Range(0.0f, 101.0f);
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
        if (timer > maxTime * 1.5)
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
                if (PercentChance(2))
                {
                    int pick = Random.Range(1, 3);
                    if (pick == 1)
                    {
                        GameObject newpaint = Instantiate(rainbow);
                        newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                    }
                    if (pick == 2)
                    {
                        GameObject newpaint = Instantiate(timesTwo);
                        newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                    }
                } else if (PercentChance(score/80.0f))
                {
                    // If AIR is empty
                    if (obstaclePositions[0] == 0.7f)
                    {
                        // The block moves up
                        if (newblock.transform.position.y > newblock2.transform.position.y)
                        {
                            newblock.GetComponent<Block>().moving = 0.5f;
                            newblock.GetComponent<Block>().moveMax = 0.7f;
                            newblock.GetComponent<Block>().moveMin = -0.1f;
                        }
                        else
                        {
                            newblock2.GetComponent<Block>().moving = 0.5f;
                            newblock2.GetComponent<Block>().moveMax = 0.7f;
                            newblock2.GetComponent<Block>().moveMin = -0.1f;
                        }
                    }

                    // If WATER is empty
                    if (obstaclePositions[0] == -0.9f)
                    {
                        // The block moves down
                        if (newblock.transform.position.y < newblock2.transform.position.y)
                        {
                            newblock.GetComponent<Block>().moving = -0.5f;
                            newblock.GetComponent<Block>().moveMax = -0.1f;
                            newblock.GetComponent<Block>().moveMin = -0.9f;
                        }
                        else
                        {
                            newblock2.GetComponent<Block>().moving = -0.5f;
                            newblock2.GetComponent<Block>().moveMax = -0.1f;
                            newblock2.GetComponent<Block>().moveMin = -0.9f;
                        }
                    }

                    // If GROUND is empty
                    if (obstaclePositions[0] == -0.1f)
                    {
                        // The block moves down
                        if (newblock.transform.position.y < newblock2.transform.position.y)
                        {
                            int pickBlock = Random.Range(1, 2);
                            if (pickBlock == 1)
                            {
                                newblock.GetComponent<Block>().moving = 0.5f;
                                newblock.GetComponent<Block>().moveMax = -0.1f;
                                newblock.GetComponent<Block>().moveMin = -0.9f;
                            } else
                            {
                                newblock2.GetComponent<Block>().moving = -0.5f;
                                newblock2.GetComponent<Block>().moveMax = 0.7f;
                                newblock2.GetComponent<Block>().moveMin = -0.1f;
                            }
                        }
                        else
                        {
                            int pickBlock = Random.Range(1, 2);
                            if (pickBlock == 1)
                            {
                                newblock.GetComponent<Block>().moving = -0.5f;
                                newblock.GetComponent<Block>().moveMax = 0.7f;
                                newblock.GetComponent<Block>().moveMin = -0.1f;
                            }
                            else
                            {
                                newblock2.GetComponent<Block>().moving = 0.5f;
                                newblock2.GetComponent<Block>().moveMax = -0.1f;
                                newblock2.GetComponent<Block>().moveMin = -0.9f;
                            }
                        }
                    }
                }
            }

            timer = 0;
            score += 1 + player.babyPuffins;
        }
        timer += Time.deltaTime;
    }

    // Adding high scores
    public IEnumerator AddNewHighScore(int score)
    {
        uploadScoreUI.sprite = loadingSprite;
        uploadScoreUI.color = new Color(1, 1, 1, 0.75f);

        UnityWebRequest uwr = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(playerUsername) + "/" + score + "/" + "0" + "/" + playerCountry);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error Uploading: " + uwr.error);
            uploadScoreUI.transform.rotation = Quaternion.identity;
            uploadScoreUI.sprite = errorSprite;
            
            yield return new WaitForSeconds(3);
            StartCoroutine(AddNewHighScore(score));
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
            uploadScoreUI.transform.rotation = Quaternion.identity;
            uploadScoreUI.sprite = uploadedSprite;
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
            int time = int.Parse(entryInfo[2]);
            string country = entryInfo[3];
            highScoresList[i] = new Highscore(username, score, time, country);
        }
    }

    public struct Highscore
    {
        public string username;
        public int score;
        public int time;
        public string country;

        public Highscore(string _username, int _score, int _time, string _country)
        {
            username = _username;
            score = _score;
            time = _time;
            country = _country;
        }
    }

    // Opens Language prompt
    public void OpenLanguagePrompt()
    {
        usernameInputUI.SetActive(false);
        languageTableUI.SetActive(true);
    }

    // Open username prompt
    public void OpenUsernamePrompt()
    {
        usernameInputUI.SetActive(true);
        mainMenuUI.SetActive(false);
    }

    public void GetUsername(string name)
    {
        playerUsername = name;
    }

    // Save Username
    public void SaveUsername(string name, string language)
    {
        playerUsername = name;
        playerLanguage = language;
        SaveSystem.SaveUsername(this);
    }

    // Load Username
    public void LoadUsername()
    {
        SaveData data = SaveSystem.LoadUsername();

        playerUsername = data.playerUsername;
        playerLanguage = data.playerLanguage;
    }

    // Get location
    public void GetDetails()
    {
        playerRegion = Localizer.GetDetails["region"];

        if (playerRegion == "Quebec")
        {
            playerCountry = "pq";
        }
        else if (playerRegion == "Catalonia")
        {
            playerCountry = "catalonia";
        }
        else if (playerRegion == "Pais Vasco")
        {
            playerCountry = "bc";
        }
        else if (playerRegion == "Xinjiang")
        {
            playerCountry = "xj";
        }
        else if (playerRegion == "Kosovsko-Mitrovacki okrug")
        {
            playerCountry = "xk";
        }
        else
        {
            playerCountry = Localizer.GetDetails["country_code"];
        }
    }

    private void Awake()
    {
        Invoke("GetDetails", 1.0f);
}

    // Code for start of script
    public void Start()
    {
        uploadScoreUI.sprite = null;
        uploadScoreUI.color = new Color(1, 1, 1, 0f);

        LoadUsername();
        if (playerLanguage == "" || playerUsername == null)
        {
            languageTableUI.SetActive(true);
            usernameInputUI.SetActive(false);
            mainMenuUI.SetActive(false);
        } else if (playerUsername == "" || playerUsername == null)
        {
            usernameInputUI.SetActive(true);
            mainMenuUI.SetActive(false);
        }
        else // If the player's username and language has already been set
        {
            language.SendMessage(playerLanguage, null, SendMessageOptions.DontRequireReceiver);
            usernameInputUI.SetActive(false);
            mainMenuUI.SetActive(true);
            Time.timeScale = 1;
        }

        canContinue = true;
        score = 0;
        DownloadHighScores();

        StartCoroutine("RefreshHighscores");
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        // Clear all display text and flags
        tablePlaceUI.text = "";
        tableUsernameUI.text = "";
        tableScoreUI.text = "";
        tableCountryUI.GetComponent<TMPro.TextMeshProUGUI>().text = "";

        // Populate the score table
        for (int i = 0; i <= 99; i++)
        {
            // Score
            tableScoreUI.text += highscoreList[i].score + "\n";

            // Username
            tableUsernameUI.text += highscoreList[i].username + "\n";

            // Country
            if (highscoreList[i].country == null || highscoreList[i].country == "")
            {
                tableCountryUI.GetComponent<TMPro.TextMeshProUGUI>().text += " \n";
            } else
            {
                tableCountryUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<sprite name=" + "\"" + highscoreList[i].country.ToLower() + "\"" + "> \n";
            }

            // Place
            if (i < 9)
            {
                tablePlaceUI.text += "00";
            }

            if (i > 8 && i < 99)
            {
                tablePlaceUI.text += "0";
            }

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

    public void XButtonScore()
    {
        highScoreTableUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }

    public void XButtonLanguage()
    {
        languageTableUI.SetActive(false);
        usernameInputUI.SetActive(true);
    }

    public void OKButton()
    {
        if (usernameInputUI.activeInHierarchy == true)
        {
            if (playerUsername.Contains(" ") || playerUsername.Contains("*"))
            {
                warningBoxText.text = language.Warning1;
            }
            else if (playerUsername.Length < 1 || playerUsername.Length > 12)
            {
                warningBoxText.text = language.Warning2;
            }
            else
            {
                SaveUsername(playerUsername, playerLanguage);
                usernameInputUI.SetActive(false);
                mainMenuUI.SetActive(true);
                warningBoxText.text = "";
            }
        }
    }

    public string ToRoman(int score)
    {
        if (score >= 1000) return "Ⅿ" + ToRoman(score - 1000);
        if (score >= 900) return "ⅭⅯ" + ToRoman(score - 900);
        if (score >= 500) return "Ⅾ" + ToRoman(score - 500);
        if (score >= 400) return "ⅭⅮ" + ToRoman(score - 400);
        if (score >= 100) return "Ⅽ" + ToRoman(score - 100);
        if (score >= 90) return "ⅩⅭ" + ToRoman(score - 90);
        if (score >= 50) return "Ⅼ" + ToRoman(score - 50);
        if (score >= 40) return "ⅩⅬ" + ToRoman(score - 40);
        if (score >= 10) return "Ⅹ" + ToRoman(score - 10);
        if (score >= 9) return "Ⅸ" + ToRoman(score - 9);
        if (score >= 5) return "Ⅴ" + ToRoman(score - 5);
        if (score >= 4) return "Ⅳ" + ToRoman(score - 4);
        if (score >= 1) return "Ⅰ" + ToRoman(score - 1);
        return "";
    }

    public void Update()
    {
        if (uploadScoreUI.sprite == loadingSprite)
        {
            uploadScoreUI.transform.Rotate(0, 0, 10, Space.Self);
        }

        WhiteC = new Color(1f, 1f, 1f, 1f);

        // Pick colour palette
        if (colourblindMode == 0)
        {
            // Normal Vision
            RedC = new Color(1f, 0.1f, 0.1f, 1f);
            OrangeC = new Color(1f, 0.5f, 0.1f, 1f);
            YellowC = new Color(1f, 1f, 0.1f, 1f);
            GreenC = new Color(0.1f, 1f, 0.1f, 1f);
            BlueC = new Color(0.1f, 0.2f, 1f, 1f);
            PurpleC = new Color(0.7f, 0.1f, 1f, 1f);
        }

        if (colourblindMode == 1)
        {
            // Protanopia (Red/Green)
            RedC = new Color(0.245283f, 0.243449f, 0f, 1f);
            OrangeC = new Color(0.3584906f, 0.3584906f, 0.3584906f, 1f);
            YellowC = new Color(1f, 0.985849f, 0.5613208f, 1f);
            GreenC = new Color(0.7668899f, 0.7924528f, 0f, 1f);
            BlueC = new Color(0f, 0.1828625f, 1f, 1f);
            PurpleC = new Color(0.05743195f, 0.0520648f, 0.245283f, 1f);
        }

        if (colourblindMode == 2)
        {
            // Deuteranopia (Red/Green)
            RedC = new Color(1f, 0.1f, 0.1f, 1f);
            OrangeC = new Color(1f, 0.5f, 0.1f, 1f);
            YellowC = new Color(1f, 1f, 0.1f, 1f);
            GreenC = new Color(0.1f, 1f, 0.1f, 1f);
            BlueC = new Color(0.1f, 0.2f, 1f, 1f);
            PurpleC = new Color(0.7f, 0.1f, 1f, 1f);
        }

        if (colourblindMode == 3)
        {
            // Tritanopia (Blue/Yellow)
            RedC = new Color(1f, 0.1f, 0.1f, 1f);
            OrangeC = new Color(1f, 0.5f, 0.1f, 1f);
            YellowC = new Color(1f, 1f, 0.1f, 1f);
            GreenC = new Color(0.1f, 1f, 0.1f, 1f);
            BlueC = new Color(0.1f, 0.2f, 1f, 1f);
            PurpleC = new Color(0.7f, 0.1f, 1f, 1f);
        }

        // Location settings
        if (playerRegion == "" || playerRegion == null)
        {
            tableFlagUI.color = new Color(1, 1, 1, 0);
        } else
        {
            tableFlagUI.color = new Color(1, 1, 1, 1);

            if (playerRegion == "Quebec")
            {
                tableFlagUI.sprite = Resources.Load<Sprite>("Flags/pq");
            }
            else if (playerRegion == "Catalonia")
            {
                tableFlagUI.sprite = Resources.Load<Sprite>("Flags/catalonia");
            }
            else if (playerRegion == "Pais Vasco")
            {
                tableFlagUI.sprite = Resources.Load<Sprite>("Flags/catalonia");
            }
            else if (playerRegion == "Xinjiang")
            {
                tableFlagUI.sprite = Resources.Load<Sprite>("Flags/xj");
            }
            else if (playerRegion == "Kosovsko-Mitrovacki okrug")
            {
                tableFlagUI.sprite = Resources.Load<Sprite>("Flags/xk");
            }
            else
            {
                tableFlagUI.sprite = Resources.Load<Sprite>("Flags/" + playerCountry.ToLower());
                tableFlagUI.color = new Color(1, 1, 1, 1);
            }
        }

        // Render menu colours to match in game colours
        redImage.color = RedC;
        orangeImage.color = OrangeC;
        yellowImage.color = YellowC;
        greenImage.color = GreenC;
        blueImage.color = BlueC;
        purpleImage.color = PurpleC;

        // Set up text based on language
        gameTitleText.GetComponent<TMPro.TextMeshProUGUI>().text = language.GameTitle.text;
        startButtonText.text = language.StartButton;
        scoreButtonText.text = language.Score;
        helloUsernameText.text = playerUsername;

        gameOverText.text = language.GameOver;
        replayButtonText.text = language.Replay;
        continueButtonText.text = language.Continue;

        if (playerLanguage != "Latin")
        {
            scoreText.text = score.ToString();
        } else
        {
            scoreText.text = ToRoman(score);
        }

        pauseText.text = language.Paused;

        highScoresText.text = language.HighScores;

        nameFillInText.text = language.Name;
        okButtonText.text = language.OK;

        if (paused == false)
        {
            Time.timeScale = 1.0f + (score / 9999.0f);
        }

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
            XButtonScore();
        }

        if (score >= 9999)
        {
            score = 9999;
            ClearObstacles();
            canContinue = false;
            player.KillPlayer();
        }
    }

    //Display game over overlay and upload high score when the player dies
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

        obstacles = GameObject.FindGameObjectsWithTag("TimesTwo");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    public void ContinueButton()
    {
        uploadScoreUI.sprite = null;
        uploadScoreUI.color = new Color(1, 1, 1, 0f);
        ClearObstacles();
        canContinue = false;
        Time.timeScale = 1f;
        player.dead = false;
        gameOverCanvas.SetActive(false);
        player.position = "starting";
    }
}

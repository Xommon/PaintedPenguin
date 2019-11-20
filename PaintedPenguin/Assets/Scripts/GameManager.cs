﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
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
    public Image redImage;
    public Image orangeImage;
    public Image yellowImage;
    public Image greenImage;
    public Image blueImage;
    public Image purpleImage;
    public FlexibleColorPicker flexibleColourPicker;
    public GameObject colourPickerUI;
    public CanvasScaler canvasScaler;
    public float scaleRatio;
    public GameObject textContainer;
    public GameObject pauseButtonImage;
    public Text currentNameFieldUI;
    public bool playerTutorialEnabled;
    public Toggle tutorialToggle;
    public GameObject tutorialWindow;
    public InputField usernameInputField;
    public Text usernameInputFieldText;
    public GameObject credits;
    public Text currentLanguageDisplay;
    public Text settingsUI;
    public Text soundUI;
    public Text musicUI;
    public Text tutorialUI;
    public Text editColoursUI;
    public Text tutorialPaint;
    public Text tutorialBlocks;
    public AudioManager audioManager;

    // Volume
    public float playerSound;
    public float playerMusic;
    public float tempPlayerSound;
    public float tempPlayerMusic;
    public Slider soundSlider;
    public Slider musicSlider;

    // Buttons
    public GameObject startButton;
    public GameObject scoreButton;

    // TEST
    public float screenHeight;
    public float screenWidth;

    // Location
    public string playerRegion;
    public string playerCountry;

    // Colours
    [SerializeField]
    public Color WhiteC;
    [SerializeField]
    public Color RedC;
    [SerializeField]
    public Color OrangeC;
    [SerializeField]
    public Color YellowC;
    [SerializeField]
    public Color GreenC;
    [SerializeField]
    public Color BlueC;
    [SerializeField]
    public Color PurpleC;

    // Game components
    public bool on;
    public int score;
    public PlayerMovement player;
    public bool canContinue;
    public Image uploadScoreUI;
    public Image downloadScoreUI;
    public Sprite loadingSprite;
    public Sprite uploadedSprite;
    public Sprite errorSprite;
    public ParticleSystem snow;
    public GameObject snowUI;

    // High scores
    const string privateCode = "cQ87T8a7BUGRQmQNMDB6iwWUTDoSubyUOyfJ9_43b3_g";
    const string publicCode = "5d43646f76827f1758cfaa7c";
    const string webURL = "dreamlo.com/lb/";
    public Highscore[] highScoresList;
    public GameObject highScoreTableUI;
    public GameObject tableInfoUI;
    public TMP_Text tableUsernameUI;
    public GameObject tableScoreUI;
    public Image tableFlagUI;
    public Sprite defaultFlag;
    public GameObject usernameInputUI;
    public Scrollbar highScoreTablUIScrollbar;
    public string playerUsername;
    public string playerLanguage;
    public string tempLanguage;

    // Records
    public int playerTime;

    // Languages
    public Language language;
    public GameObject languageTableUI;

    public TMP_Text gameTitleText;
    public Text startButtonText;
    public Text scoreButtonText;
    public Text usernameDisplayText;
    public TMP_Text comboText;

    public Text gameOverText;
    public Text replayButtonText;
    public Text continueButtonText;

    public TMP_Text scoreText;

    public Text pauseText;

    public Text highScoresText;

    public Text colourPickerText;

    public Text languagePromptText;

    public Text nameFillInText;
    public Text okButtonText;
    public Text warningBoxText;
    public Text nameSlot;

    // Obstacle creation
    public float maxTime = 1;
    private float timer = 0;
    public int wave;
    public GameObject block;
    public GameObject blockWithPaint;
    public GameObject blockWithRainbow;
    public GameObject blockWithTimesThree;
    public GameObject blockWithBaby;
    public GameObject blockWithMagnet;
    public GameObject blockWithFist;
    public GameObject paint;
    public GameObject rainbow;
    public GameObject timesTwo;
    public GameObject spikeBall;
    public float blockWithFistPercent;
    float place;
    public List<float> obstaclePositions = new List<float>();

    public bool PercentChance(float percent)
    {
        if (percent > 100)
        {
            percent = 100;
        }
        else if (percent < 0)
        {
            percent = 0;
        }

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

            // Increment wave
            wave++;

            // Place first block
            GameObject newblock = null;
            if (score >= 500)
            {
                if ((score / 66.66f) <= 60)
                {
                    if (PercentChance(score / 66.66f))
                    {
                        if (PercentChance(95))
                        {
                            newblock = Instantiate(blockWithPaint);
                        }
                        else
                        {
                            newblock = Instantiate(blockWithTimesThree);
                        }
                    }
                    else
                    {
                        newblock = Instantiate(block);
                    }
                }
                else
                {
                    if (PercentChance(60))
                    {
                        if (PercentChance(92))
                        {
                            newblock = Instantiate(blockWithPaint);
                        }
                        else
                        {
                            newblock = Instantiate(blockWithTimesThree);
                        }
                    }
                    else if (score > 3150 && PercentChance(blockWithFistPercent))
                    {
                        newblock = Instantiate(blockWithFist);
                    }
                    else
                    {
                        newblock = Instantiate(block);
                    }
                }
            }
            else
            {
                newblock = Instantiate(block);
            }
            newblock.GetComponent<Block>().wave = wave;
            place = obstaclePositions[(Random.Range(0, 3))]; // 0, 1 or 2
            newblock.transform.position = transform.position + new Vector3(1, place, 0);
            obstaclePositions.Remove(place);

            // Place second block
            GameObject newblock2 = null;

            if (newblock.name == "BlockWithFist" || newblock.name == "BlockWithFist(Clone)")
            {
                newblock2 = null;
            }
            else
            {
                if (score >= 1000)
                {
                    if (PercentChance(5.0f))
                    {
                        if (PercentChance(25.0f))
                        {
                            newblock2 = Instantiate(blockWithRainbow);
                        }
                        else if (PercentChance(33.33f))
                        {
                            newblock2 = Instantiate(blockWithTimesThree);
                        }
                        else if (PercentChance(50.0f))
                        {
                            newblock2 = Instantiate(blockWithMagnet);
                        }
                        else
                        {
                            if (player.babyPuffins < 3)
                            {
                                newblock2 = Instantiate(blockWithBaby);
                            }
                            else
                            {
                                newblock2 = Instantiate(block);
                            }
                        }
                    }
                    else if (PercentChance(SpikeballEquation()))
                    {
                        newblock2 = Instantiate(spikeBall);
                    }
                    else if (PercentChance(score / 750.0f))
                    {
                        newblock2 = Instantiate(blockWithPaint);
                    }
                    else
                    {
                        newblock2 = Instantiate(block);
                    }
                }
                else if (score >= 400 && score < 1000)
                {
                    if (PercentChance(1))
                    {
                        if (player.babyPuffins < 3)
                        {
                            newblock2 = Instantiate(blockWithBaby);
                        }
                        else
                        {
                            newblock2 = Instantiate(block);
                        }
                    }
                    else
                    {
                        newblock2 = Instantiate(block);
                    }
                }
                else
                {
                    newblock2 = Instantiate(block);
                }
            }

            if (newblock2 != null)
            {
                if (newblock2.tag == "Block")
                {
                    newblock2.GetComponent<Block>().wave = wave;
                }
                place = obstaclePositions[(Random.Range(0, 2))]; // 0 or 1
                newblock2.transform.position = transform.position + new Vector3(1, place, 0);
                obstaclePositions.Remove(place);
            }

            // Place paint
            GameObject newpaint = null;
            if (newblock.name == "BlockWithFist" || newblock.name == "BlockWithFist(Clone)")
            {
                if (PercentChance(75))
                {
                    if (newblock.transform.position.y == -0.9f || newblock.transform.position.y == 0.7f)
                    {
                        if (PercentChance(20))
                        {
                            newpaint = Instantiate(block);
                        }
                        else if (PercentChance(3))
                        {
                            newpaint = Instantiate(blockWithRainbow);
                        }
                        else if (PercentChance(3))
                        {
                            newpaint = Instantiate(blockWithTimesThree);
                        }
                        else
                        {
                            newpaint = Instantiate(blockWithPaint);
                        }
                        newpaint.transform.position = transform.position + new Vector3(1, -0.1f, 0);
                    }
                    else
                    {
                        newpaint = Instantiate(paint);
                        newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                    }
                }
                else
                {
                    newpaint = Instantiate(paint);
                    newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                }
            }
            else
            {
                if (PercentChance(25))
                {
                    newpaint = Instantiate(paint);
                    newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                }
                else //75%
                {
                    if (PercentChance(2)) // TEST 2%
                    {
                        int pick;
                        pick = Random.Range(1, 3);

                        if (pick == 1)
                        {
                            newpaint = Instantiate(rainbow);
                            newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                        }
                        if (pick == 2)
                        {
                            newpaint = Instantiate(timesTwo);
                            newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                        }
                    }
                    else if (newblock2 != null && PercentChance(score / 80.0f))
                    {
                        if (newblock2.tag == "Block")
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
                                    }
                                    else
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
                }
            }
            
            newblock.GetComponent<Block>().wave = wave;

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

        UnityWebRequest uwr = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(playerUsername) + "/" + score + "/" + playerTime + "/" + playerCountry);
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error Uploading: " + uwr.error);
            uploadScoreUI.transform.rotation = Quaternion.identity;
            uploadScoreUI.sprite = errorSprite;

            // If there's an error, keep retrying to submit score every 5 seconds
            yield return new WaitForSeconds(5);
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
        downloadScoreUI.sprite = loadingSprite;
        downloadScoreUI.color = new Color(1, 1, 1, 0.75f);

        UnityWebRequest uwr = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            downloadScoreUI.transform.rotation = Quaternion.identity;
            downloadScoreUI.sprite = errorSprite;
            Debug.Log("Error Downloading: " + uwr.error);
        }
        else
        {
            downloadScoreUI.color = new Color(1, 1, 1, 0f);
            downloadScoreUI.transform.rotation = Quaternion.identity;
            downloadScoreUI.sprite = null;

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
        playerSound = tempPlayerSound;
        playerMusic = tempPlayerMusic;
        usernameInputUI.SetActive(false);
        languageTableUI.SetActive(true);
    }

    // Open username prompt
    public void OpenUsernamePrompt()
    {
        currentNameFieldUI.text = playerUsername;
        usernameInputUI.SetActive(true);
        mainMenuUI.SetActive(false);
        tempPlayerSound = playerSound;
        tempPlayerMusic = playerMusic;
        tempLanguage = playerLanguage;
    }

    public void GetUsername(string name)
    {
        playerUsername = name;
    }

    // Save Data
    public void SaveUsername(string name, string language, Color red, Color orange, Color yellow, Color green, Color blue, Color purple, float sound, float music, bool tutorial)
    {
        playerUsername = name;
        playerLanguage = language;
        RedC = red;
        OrangeC = orange;
        YellowC = yellow;
        GreenC = green;
        BlueC = blue;
        PurpleC = purple;
        playerSound = sound;
        playerMusic = music;
        playerTutorialEnabled = tutorial;
        SaveSystem.SaveData(this);
    }

    // Load Data
    public void LoadUsername()
    {
        SaveData data = SaveSystem.LoadData();

        if (SaveSystem.SaveFileExists())
        {
            playerUsername = data.playerUsername;
            nameFillInText.text = data.playerUsername;
            playerLanguage = data.playerLanguage;
            RedC = HexToColour(data.playerRed);
            OrangeC = HexToColour(data.playerOrange);
            YellowC = HexToColour(data.playerYellow);
            GreenC = HexToColour(data.playerGreen);
            BlueC = HexToColour(data.playerBlue);
            PurpleC = HexToColour(data.playerPurple);
            playerSound = data.playerSound;
            playerMusic = data.playerMusic;
            soundSlider.value = data.playerSound;
            musicSlider.value = data.playerMusic;
            tutorialToggle.isOn = data.playerTutorialEnabled;
        }
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
            playerCountry = "ct";
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
        else if (playerRegion == "Tibet")
        {
            playerCountry = "tb";
        }
        else if (playerRegion == "Scotland")
        {
            playerCountry = "zs";
        }
        else if (playerRegion == "Wales")
        {
            playerCountry = "wa";
        }
        else if (playerRegion == "Abkhazia")
        {
            playerCountry = "xa";
        }
        else if (playerRegion == "South Ossetia")
        {
            playerCountry = "xo";
        }
        else
        {
            playerCountry = Localizer.GetDetails["country_code"];
        }
    }

    private void Awake()
    {
        Invoke("GetDetails", 1.0f);
        wave = 0;
    }

    private int HexToDec(string hex)
    {
        int dec = System.Convert.ToInt32(hex, 16);
        return dec;
    }

    private string DecToHex(int value)
    {
        return value.ToString("X2");
    }

    private string FloatNormalizedToHex(float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    private float HexToFloatNormalized(string hex)
    {
        return HexToDec(hex) / 255f;
    }

    public Color HexToColour(string hexString)
    {
        float red = HexToFloatNormalized(hexString.Substring(0, 2));
        float green = HexToFloatNormalized(hexString.Substring(2, 2));
        float blue = HexToFloatNormalized(hexString.Substring(4, 2));
        return new Color(red, green, blue);
    }

    public string ColourToHex(Color colour)
    {
        return ColorUtility.ToHtmlStringRGB(colour);
    }

    // Code for start of script
    public void Start()
    {
        // Reset time
        playerTime = 0;

        // Load all save data
        //SaveSystem.DeleteData(); // Clear save data
        LoadUsername();
        //credits.GetComponent<Credits>().creditsEnabled = true;

        // Set weather
        string date = System.DateTime.Now.ToString("ddMM");
        if (date.Substring(2, 2) == "11")
        {
            snowUI.SetActive(true);
            snow.emissionRate = float.Parse(date.Substring(0, 2)) * 3.33f;
        }
        else if (date.Substring(2, 2) == "12")
        {
            snow.emissionRate = float.Parse(date.Substring(0, 2)) * 3.33f + 100.0f;
        }
        else if (date.Substring(2, 2) == "01")
        {
            snow.emissionRate = 200.0f - float.Parse(date.Substring(0, 2)) * 3.33f;
        }
        else if (date.Substring(2, 2) == "02")
        {
            snow.emissionRate = 100.0f - float.Parse(date.Substring(0, 2)) * 3.33f;
        }
        else
        {
            snow.emissionRate = 0;
        }

        // Set default colours if no colours are saved on file
        WhiteC = new Color(1f, 1f, 1f, 0f);
        if (RedC.a < 1)
        {
            RedC = new Color(1f, 0.1f, 0.1f, 1f);
        }
        if (OrangeC.a < 1)
        {
            OrangeC = new Color(1f, 0.5f, 0.1f, 1f);
        }
        if (YellowC.a < 1)
        {
            YellowC = new Color(1f, 1f, 0.1f, 1f);
        }
        if (GreenC.a < 1)
        {
            GreenC = new Color(0.1f, 1f, 0.1f, 1f);
        }
        if (BlueC.a < 1)
        {
            BlueC = new Color(0.1f, 0.2f, 1f, 1f);
        }
        if (PurpleC.a < 1)
        {
            PurpleC = new Color(0.7f, 0.1f, 1f, 1f);
        }

        uploadScoreUI.sprite = null;
        uploadScoreUI.color = new Color(1, 1, 1, 0f);

        // Set up default options if there is no save file
        if (playerLanguage == "" || playerLanguage == null)
        {
            usernameInputUI.SetActive(true);
            mainMenuUI.SetActive(false);
            language.English();
            playerSound = 100;
            playerMusic = 100;
            tempPlayerSound = playerSound;
            tempPlayerMusic = playerMusic;
        }
        else // If the player's username and language has already been set
        {
            language.SendMessage(playerLanguage, null, SendMessageOptions.DontRequireReceiver);
            usernameInputUI.SetActive(false);
            mainMenuUI.SetActive(true);
            credits.GetComponent<Credits>().count = 0;
            Time.timeScale = 1;
        }

        canContinue = true;
        score = 0;
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        // Clear all display text and flags
        tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        int previousScore = 0;
        int previousPlace = 0;
        int count = 0;

        // Populate the score table
        for (int i = 0; i <= 99; i++)
        {
            // Place
            int place = 0;

            if (highscoreList[i].username == playerUsername)
            {
                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<color=white>";
            }
            else
            {
                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<color=black>";
            }

            if (highscoreList[i].score == previousScore)
            {
                if (previousPlace == 0)
                {
                    previousPlace = i;
                } else
                {
                    count++;
                }
                place = i - count + 1;
            } else
            {
                count = 0;
                place = i + 1;
            }

            if (place < 10)
            {
                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "00";
            }
            else if (place > 9 && place < 100)
            {
                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "0";
            }

            tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += place + ": ";

            // Country
            if (highscoreList[i].country == null || highscoreList[i].country == "")
            {
                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<sprite name=" + "\"none\"" + "> ";
            }
            else
            {
                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<sprite name=" + "\"" + highscoreList[i].country.ToLower() + "\"" + ">";
            }

            // Username
            tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += " " + language.Arabizer(highscoreList[i].username) + "\n";

            if (i == 99)
            {
                tableUsernameUI.text += "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n";
            }

            // Score
            if (highscoreList[i].username == playerUsername)
            {
                tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<color=white>";
            }
            else
            {
                tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<color=black>";
            }

            previousScore = highscoreList[i].score;
            if (highscoreList[i].score < 999)
            {
                tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text += highscoreList[i].score;
            }
            else if (highscoreList[i].score > 999 && highscoreList[i].score <= 9999)
            {
                tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text += highscoreList[i].score.ToString().Substring(0, 1) + language.numberSeparator + highscoreList[i].score.ToString().Substring(1, 3);
            }
            else if (highscoreList[i].score > 9999 && highscoreList[i].score <= 99999)
            {
                tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text += highscoreList[i].score.ToString().Substring(0, 2) + language.numberSeparator + highscoreList[i].score.ToString().Substring(2, 3);
            }
            else if (highscoreList[i].score > 99999)
            {
                tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text += "MAX";
            }

            tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text += "\n";
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
        if (playerTutorialEnabled == true)
        {
            tutorialWindow.SetActive(true);
            player.Invoke("StartWalking", 24.0f);
        }
        else
        {
            tutorialWindow.SetActive(false);
            player.StartWalking();
        }
        mainMenuUI.SetActive(false);
        gameUI.SetActive(true);
    }
    
    // Score Button pressed
    public void ScoreButton()
    {
        mainMenuUI.SetActive(false);
        highScoreTableUI.SetActive(true);
        StartCoroutine("RefreshHighscores");
    }

    public void XButtonScore()
    {
        highScoreTableUI.SetActive(false);
        mainMenuUI.SetActive(true);
        credits.GetComponent<Credits>().count = 0;
    }

    public void XButtonSettings()
    {
        if (SaveSystem.SaveFileExists() == true || usernameInputFieldText.text.Length > 0)
        {
            credits.GetComponent<Credits>().count = 0;
            playerSound = tempPlayerSound;
            playerMusic = tempPlayerMusic;
            language.SendMessage(tempLanguage, null, SendMessageOptions.DontRequireReceiver);
            usernameInputUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }
    }

    public void XButtonLanguage()
    {
        language.UpdateFontSettings();
        languageTableUI.SetActive(false);
        usernameInputUI.SetActive(true);
        tempPlayerSound = playerSound;
        tempPlayerMusic = playerMusic;
        currentNameFieldUI.text = playerUsername;
    }
    
    public void OKButton()
    {
        if (usernameInputUI.activeInHierarchy == true)
        {
            string nonLatinChars = "";

            for (int i = 0; i < nameSlot.text.Length; i++)
            {
                if (language.LatinCharacter(nameSlot.text.Substring(i, 1)) == false)
                {
                    nonLatinChars += nameSlot.text.Substring(i, 1);
                }
            }

            if (nonLatinChars != "")
            {
                warningBoxText.text = language.Warning4 + ": " + nonLatinChars;
            }
            else if (nameSlot.text.Contains(" ") || nameSlot.text.Contains("*"))
            {
                warningBoxText.text = language.Warning1;
            }
            else if (nameSlot.preferredWidth > 168)
            {
                warningBoxText.text = language.Warning2;
            }
            else if ((nameSlot.text == "" || nameSlot.text == null) && (playerUsername == "" || playerUsername == null))
            {
                warningBoxText.text = language.Warning3;
            }
            else
            {
                usernameInputUI.SetActive(false);
                mainMenuUI.SetActive(true);
                credits.GetComponent<Credits>().count = 0;
                warningBoxText.text = "";
                playerSound = soundSlider.value;
                playerMusic = musicSlider.value;
                playerTutorialEnabled = tutorialToggle.isOn;
                if (usernameInputFieldText.text == "" || usernameInputFieldText.text == null)
                {
                    GetUsername(playerUsername);
                }
                else
                {
                    GetUsername(usernameInputFieldText.text);
                }
                SaveUsername(playerUsername, playerLanguage, RedC, OrangeC, YellowC, GreenC, BlueC, PurpleC, playerSound, playerMusic, playerTutorialEnabled);
            }
        }
    }

    public string ToRoman(int score)
    {
        if (score >= 1000) return "M" + ToRoman(score - 1000);
        if (score >= 900) return "CM" + ToRoman(score - 900);
        if (score >= 500) return "D" + ToRoman(score - 500);
        if (score >= 400) return "CD" + ToRoman(score - 400);
        if (score >= 100) return "C" + ToRoman(score - 100);
        if (score >= 90) return "XC" + ToRoman(score - 90);
        if (score >= 50) return "L" + ToRoman(score - 50);
        if (score >= 40) return "XL" + ToRoman(score - 40);
        if (score >= 10) return "X" + ToRoman(score - 10);
        if (score >= 9) return "IX" + ToRoman(score - 9);
        if (score >= 5) return "V" + ToRoman(score - 5);
        if (score >= 4) return "IV" + ToRoman(score - 4);
        if (score >= 1) return "I" + ToRoman(score - 1);
        return "";
    }

    public float SpikeballEquation()
    {
        if (score > 1750)
        {
            if (score / 1166.67f < 45.0f)
            {
                return (score / 333.33f);
            }
            else
            {
                return 45.0f;
            }
        }
        else
        {
            return 0.0f;
        }
    }

    public void ToggleChanged(bool newValue)
    {
        playerTutorialEnabled = newValue;
    }

    public void Update()
    {
        // TEST!!!
        if (Input.GetKeyDown("q"))
        {
            FindObjectOfType<AudioManager>().Play("powerup");
        }

        // Keep track of player time
        if (on == true && player.dead == false)
        {
            playerTime += Mathf.RoundToInt(Time.deltaTime);
        }

        // Update volume
        if (usernameInputUI.activeInHierarchy)
        {
            playerSound = soundSlider.value;
            playerMusic = musicSlider.value;
        }

        // Always display current language
        currentLanguageDisplay.text = language.LanguageName.ToUpper();

        // Spin the pause button when the game is paused
        if (paused == true)
        {
            pauseButtonImage.transform.Rotate(0, 1.5f, 0);
        }
        else
        {
            pauseButtonImage.transform.rotation = Quaternion.identity;
        }

        // TEST
        screenHeight = Screen.height;
        screenWidth = Screen.width;

        scaleRatio = screenHeight / 800;

        // Fill in name slot
        nameSlot.text = playerUsername;

        // Rotate Uploading and Downloading Sprites
        if (uploadScoreUI.sprite == loadingSprite)
        {
            uploadScoreUI.transform.Rotate(0, 0, 10, Space.Self);
        }

        if (downloadScoreUI.sprite == loadingSprite)
        {
            downloadScoreUI.transform.Rotate(0, 0, 10, Space.Self);
        }

        // BlockWithFist percent
        if ((score - 3150.0f) / 69.0f <= 70.0f)
        {
            blockWithFistPercent = (score - 3150.0f) / 69.0f;
        }
        else
        {
            blockWithFistPercent = 70.0f;
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
            else if (playerRegion == "Scotland")
            {
                tableFlagUI.sprite = Resources.Load<Sprite>("Flags/xk");
            }
            else
            {
                tableFlagUI.sprite = Resources.Load<Sprite>("Flags/" + playerCountry.ToLower());
                tableFlagUI.color = new Color(1, 1, 1, 1);
            }
        }

        // Set up text based on language
        gameTitleText.outlineWidth = 0;
        gameTitleText.text = "Painted Puffin";
        startButtonText.text = language.StartButton;
        scoreButtonText.text = language.Score;
        usernameDisplayText.text = " " + playerUsername;
        comboText.text = language.Combo;

        gameOverText.text = language.GameOver;
        replayButtonText.text = language.Replay;
        continueButtonText.text = language.Continue;

        if (playerLanguage == "Latin")
        {
            scoreText.text = ToRoman(score);
        }
        else
        {
            scoreText.text = score.ToString();
        }
        
        pauseText.text = language.Paused;

        highScoresText.text = language.HighScores;

        colourPickerText.text = language.ColourPickerText.ToUpper();

        settingsUI.text = language.Settings.ToUpper();

        soundUI.text = language.Sound.ToUpper();

        musicUI.text = language.Music.ToUpper();

        tutorialUI.text = language.Tutorial.ToUpper();

        editColoursUI.text = language.ColourPickerText.ToUpper();

        if (language.Name == "" || language.Name == null)
        {
            nameFillInText.text = language.Name;
        }
        
        okButtonText.text = language.OK;

        if (paused == false)
        {
            Time.timeScale = 1.0f + (score / 99999.0f);
        }

        tutorialPaint.text = language.Paint.ToUpper();
        tutorialBlocks.text = language.Blocks.ToUpper();

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

        // Mobile back button
        if (Input.GetKeyDown("escape"))
        {
            if (highScoreTableUI.activeInHierarchy == true)
            {
                XButtonScore();
            }
            else if (colourPickerUI.activeInHierarchy == true)
            {
                CloseButtonCP();
            }
            else if (languageTableUI.activeInHierarchy == true)
            {
                XButtonLanguage();
            }
            else if (gameUI.activeInHierarchy == true)
            {
                Pause();
            }
        }

        // Max score of 99.999
        if (score >= 100000)
        {
            score = 100000;
            ClearObstacles();
            canContinue = false;
            player.KillPlayer();
        }
    }

    //Display game over overlay and upload high score when the player dies
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        FindObjectOfType<AudioManager>().Play("deathjingle");
        if (canContinue == false)
        {
            continueButtonUI.SetActive(false);
        }
    }

    public void RestartGame()
    {
        gameUI.SetActive(false);
        SceneManager.LoadScene("PaintedPuffin");
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

        obstacles = GameObject.FindGameObjectsWithTag("SpikeBall");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }

        obstacles = GameObject.FindGameObjectsWithTag("Feather");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }

        obstacles = GameObject.FindGameObjectsWithTag("ExplosionFX");
        for (int i = 0; i < obstacles.Length; i++)
        {
            Destroy(obstacles[i]);
        }
    }

    public void ContinueButton()
    {
        player.dead = false;
        player.rb.gravityScale = 0;
        player.rb.MovePosition(new Vector2(-1.0f, -0.075f));
        uploadScoreUI.sprite = null;
        uploadScoreUI.color = new Color(1, 1, 1, 0f);
        ClearObstacles();
        if (player.colour == 7)
        {
            player.colour = 0;
        }
        canContinue = false;
        Time.timeScale = 1f;
        player.position = "ready";
        player.StartWalking();
        gameOverCanvas.SetActive(false);
    }

    // Colour picker
    public void OKButtonCP()
    {
        RedC = redImage.color;
        OrangeC = orangeImage.color;
        YellowC = yellowImage.color;
        GreenC = greenImage.color;
        BlueC = blueImage.color;
        PurpleC = purpleImage.color;
        colourPickerUI.SetActive(false);
        usernameInputUI.SetActive(true);
        tempPlayerSound = playerSound;
        tempPlayerMusic = playerMusic;
        redImage.GetComponent<FCP_ExampleScript>().fcp = null;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = null;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = null;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = null;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = null;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = null;
    }

    public void CloseButtonCP()
    {
        colourPickerUI.SetActive(false);
        usernameInputUI.SetActive(true);
        tempPlayerSound = playerSound;
        tempPlayerMusic = playerMusic;
        redImage.GetComponent<FCP_ExampleScript>().fcp = null;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = null;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = null;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = null;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = null;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = null;
    }

    public void OpenColourPicker()
    {
        redImage.color = RedC;
        orangeImage.color = OrangeC;
        yellowImage.color = YellowC;
        greenImage.color = GreenC;
        blueImage.color = BlueC;
        purpleImage.color = PurpleC;

        usernameInputUI.SetActive(false);
        colourPickerUI.SetActive(true);
    }

    public void RedButton()
    {
        flexibleColourPicker.hexInput.text = ColorUtility.ToHtmlStringRGB(redImage.color);
        redImage.GetComponent<FCP_ExampleScript>().fcp = flexibleColourPicker;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = null;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = null;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = null;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = null;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = null;
    }

    public void OrangeButton()
    {
        flexibleColourPicker.hexInput.text = ColorUtility.ToHtmlStringRGB(orangeImage.color);
        redImage.GetComponent<FCP_ExampleScript>().fcp = null;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = flexibleColourPicker;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = null;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = null;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = null;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = null;
    }

    public void YellowButton()
    {
        flexibleColourPicker.hexInput.text = ColorUtility.ToHtmlStringRGB(yellowImage.color);
        redImage.GetComponent<FCP_ExampleScript>().fcp = null;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = null;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = flexibleColourPicker;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = null;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = null;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = null;
    }

    public void GreenButton()
    {
        flexibleColourPicker.hexInput.text = ColorUtility.ToHtmlStringRGB(greenImage.color);
        redImage.GetComponent<FCP_ExampleScript>().fcp = null;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = null;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = null;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = flexibleColourPicker;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = null;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = null;
    }

    public void BlueButton()
    {
        flexibleColourPicker.hexInput.text = ColorUtility.ToHtmlStringRGB(blueImage.color);
        redImage.GetComponent<FCP_ExampleScript>().fcp = null;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = null;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = null;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = null;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = flexibleColourPicker;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = null;
    }

    public void PurpleButton()
    {
        flexibleColourPicker.hexInput.text = ColorUtility.ToHtmlStringRGB(purpleImage.color);
        redImage.GetComponent<FCP_ExampleScript>().fcp = null;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = null;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = null;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = null;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = null;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = flexibleColourPicker;
    }

    public void DefaultColourButton()
    {
        redImage.GetComponent<FCP_ExampleScript>().fcp = null;
        orangeImage.GetComponent<FCP_ExampleScript>().fcp = null;
        yellowImage.GetComponent<FCP_ExampleScript>().fcp = null;
        greenImage.GetComponent<FCP_ExampleScript>().fcp = null;
        blueImage.GetComponent<FCP_ExampleScript>().fcp = null;
        purpleImage.GetComponent<FCP_ExampleScript>().fcp = null;
        redImage.color = new Color(1f, 0.1f, 0.1f, 1f);
        orangeImage.color = new Color(1f, 0.5f, 0.1f, 1f);
        yellowImage.color = new Color(1f, 1f, 0.1f, 1f);
        greenImage.color = new Color(0.1f, 1f, 0.1f, 1f);
        blueImage.color = new Color(0.1f, 0.2f, 1f, 1f);
        purpleImage.color = new Color(0.7f, 0.1f, 1f, 1f);
    }
}

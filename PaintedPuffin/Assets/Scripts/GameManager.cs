using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public Reward2 reward2;

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
    public bool playerSwipeEnabled;
    public Toggle tutorialToggle;
    public Toggle swipeToggle;
    public GameObject tutorialWindow;
    public InputField usernameInputField;
    public Text usernameInputFieldText;
    public Credits credits;
    public Text currentLanguageDisplay;
    public Text settingsUI;
    public Text swipeUI;
    public Text soundUI;
    public Text musicUI;
    public Text tutorialUI;
    public Text editColoursUI;
    public Text tutorialPaint;
    public Text tutorialBlocks;
    public Text colourSwitchOk;
    public AudioManager audioManager;
    public bool ghostScoreReturn;
    public GameObject settingsXButton;
    public AdController adController;
    int musicCounter;
    public Animator mainMenuAnimator;
    public GameObject creditsUI;
    public float startGameCounter;
    bool gameStarting;
    public GameObject usernameDisplay;
    public GameObject settingsButton;
    public GameObject instagramButton;
    public Text version;

    // Volume
    [Range(0f, 1f)]
    public float playerSound;
    [Range(0f, 1f)]
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
    public string playerCity;

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
    public float ghostTimer;

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
    public float playerTime;

    // Languages
    public Language language;
    public GameObject languageTableUI;

    //public TMP_Text gameTitleText;
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
    public int streakCount;
    public int streakColour;
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
    public int baseValue;
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
            if (score >= 100)
            {
                if ((score / 18.33f) <= 60) // 100 to 1100
                {
                    if (PercentChance(score / 18.33f)) // 0% to 60%
                    {
                        if (PercentChance(90))
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
                        if (PercentChance(88))
                        {
                            newblock = Instantiate(blockWithPaint);
                        }
                        else
                        {
                            newblock = Instantiate(blockWithTimesThree);
                        }
                    }
                    else if (score >= 1000 && PercentChance(blockWithFistPercent))
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
                if (score >= 100)
                {
                    if (PercentChance(6.5f) && score >= 300)
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
                            if (player.babyPuffins < 3 && score >= 500)
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
                    else if (PercentChance(50))
                    {
                        newblock2 = Instantiate(blockWithPaint);
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
                place = obstaclePositions[(Random.Range(0, 2))];
                newblock2.transform.position = transform.position + new Vector3(1, place, 0);
                obstaclePositions.Remove(place);
            }

            // Place block or paint
            GameObject newpaint = null;
            if (newblock.name == "BlockWithFist" || newblock.name == "BlockWithFist(Clone)") // Score is at least 1000
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
            else // All happens if there is no fist block
            {
                if (PercentChance(25))
                {
                    newpaint = Instantiate(paint);
                    newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
                }
                else // Score >= 100
                {
                    if (PercentChance(2.5f) && score > 100)
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
                    else if (newblock2 != null && PercentChance((score - 300) / 23) && score > 100) // 300 to 1500
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

        UnityWebRequest uwr = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(playerUsername) + "/" + score + "/" + Mathf.RoundToInt(playerTime) + "/" + playerCountry);
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
        playerSound = soundSlider.value;
        playerMusic = musicSlider.value;
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
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void GetUsername(string name)
    {
        playerUsername = name;
    }

    // Save Data
    public void SaveUsername(string name, string language, Color red, Color orange, Color yellow, Color green, Color blue, Color purple, float sound, float music, bool tutorial, bool swipe)
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
        playerSwipeEnabled = swipe;
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
            swipeToggle.isOn = data.playerSwipeEnabled;
        }
    }

    private void Awake()
    {
        StartCoroutine("CollectAndAssignLocation");
        version.text = "Version: " + Application.version;
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
        //AndroidRuntimePermissions.CheckPermission("android.permission.WRITE_EXTERNAL_STORAGE");

        gameStarting = false;
        startGameCounter = 0;

        // Play music
        FindObjectOfType<AudioManager>().Play("music_menu");

        ghostTimer = 3.0f;

        // Ad
        //AdsManager.Instance.BannerShow();
        adController.ShowBanner();

        // Reset streak
        streakColour = 0;
        streakCount = 0;

        // BaseValue for Difficulty Settings
        baseValue = 100;

        // Reset time
        playerTime = 0;

        // Load all save data
        //SaveSystem.DeleteData(); // Clear and reset save data
        LoadUsername();

        // Set weather
        /*string date = System.DateTime.Now.ToString("ddMM");
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
        }*/

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

        // Set up default settings/options if there is no save file
        if (playerLanguage == "" || playerLanguage == null)
        {
            usernameInputUI.SetActive(true);
            mainMenuUI.SetActive(false);
            language.English();
            playerSound = 100;
            playerMusic = 100;
            tempPlayerSound = playerSound;
            tempPlayerMusic = playerMusic;
            playerTutorialEnabled = true;
        }
        else
        {
            language.SendMessage(playerLanguage, null, SendMessageOptions.DontRequireReceiver);
            credits.count = 0;
            credits.index = 0;
            Time.timeScale = 1;
            usernameInputUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }

        canContinue = true;
        score = -1;
    }

    public void OnHighscoresDownloaded(Highscore[] highscoreList)
    {
        // Clear all display text and flags
        tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        tableScoreUI.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        int previousScore = 0;
        int previousPlace = 0;
        int count = 0;

        int amountOfScores;
        if (highscoreList.Length < 100)
        {
            amountOfScores = highscoreList.Length;
        }
        else
        {
            amountOfScores = 99;
        }

        // Populate the score table
        for (int i = 0; i <= amountOfScores - 1; i++)
        {
            // Place
            int place = 0;
            
            // Highlights your score in white
            if (highscoreList[i].username == playerUsername)
            {
                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<color=white>";
            }
            else
            {
                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<color=black>";
            }

            // Matching scores tie in place
            if (highscoreList[i].score == previousScore)
            {
                if (previousPlace == 0)
                {
                    previousPlace = i;
                }
                else
                {
                    count++;
                }

                place = i - count + 1;
            }
            else
            {
                count = 0;
                place = i + 1;
                previousPlace = 1;
            }

            // Align places
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

                tableInfoUI.GetComponent<TMPro.TextMeshProUGUI>().text += "<sprite name=" + "\"" + highscoreList[i].country.Substring(0,2).ToLower() + "\"" + ">";
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
            //AdsManager.Instance.BannerShow();
            adController.ShowBanner();
            Time.timeScale = 0;
            paused = true;
            FindObjectOfType<AudioManager>().Pause();
        }
        else
        {
            pauseUI.SetActive(false);
            //AdsManager.Instance.BannerHide();
            adController.CloseBanner();
            Time.timeScale = 1;
            paused = false;
            FindObjectOfType<AudioManager>().Unpause();
        }
    }

    // Start Button pressed
    public void PreStartGame()
    {
        FindObjectOfType<AudioManager>().Play("click");
        //AdsManager.Instance.BannerHide();
        adController.CloseBanner();
        FindObjectOfType<AudioManager>().FadeOut("music_menu");

        startButton.SetActive(false);
        scoreButton.SetActive(false);
        creditsUI.SetActive(false);
        usernameDisplay.SetActive(false);
        settingsButton.SetActive(false);
        instagramButton.SetActive(false);
        mainMenuAnimator.enabled = true;
        gameStarting = true;

        startGameCounter = 0;
        FindObjectOfType<AudioManager>().Play("slap");
        FindObjectOfType<AudioManager>().Play("peep");
    }

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("music_game");

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
        FindObjectOfType<AudioManager>().Play("click");
    }

    public void XButtonScore()
    {
        FindObjectOfType<AudioManager>().Play("click");
        highScoreTableUI.SetActive(false);
        mainMenuUI.SetActive(true);
        credits.count = 0;
        credits.index = 0;
    }

    public void XButtonSettings()
    {
        if (SaveSystem.SaveFileExists() == true || usernameInputFieldText.text.Length > 0)
        {
            FindObjectOfType<AudioManager>().Play("click");
            usernameInputFieldText.text = "";
            credits.GetComponent<Credits>().count = 0;
            credits.GetComponent<Credits>().index = 0;
            playerSound = tempPlayerSound;
            playerMusic = tempPlayerMusic;
            language.SendMessage(tempLanguage, null, SendMessageOptions.DontRequireReceiver);
            usernameInputUI.SetActive(false);
            mainMenuUI.SetActive(true);
            soundSlider.value = playerSound;
            musicSlider.value = playerMusic;
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
            FindObjectOfType<AudioManager>().Play("click");

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
                bool onlyPeriods = false;
                for (int i = 0; i <= nameSlot.text.Length - 1; i++)
                {
                    if (nameSlot.text.Substring(i, 1) == ".")
                    {
                        onlyPeriods = true;
                    }
                    else
                    {
                        onlyPeriods = false;
                    }
                }

                if (onlyPeriods == true)
                {
                    warningBoxText.text = language.Warning5 + ": " + usernameInputFieldText.text;
                }
                else
                {
                    usernameInputUI.SetActive(false);
                    settingsXButton.SetActive(true);
                    mainMenuUI.SetActive(true);
                    credits.count = 0;
                    credits.index = 0;
                    warningBoxText.text = "";
                    playerSound = soundSlider.value;
                    playerMusic = musicSlider.value;
                    playerTutorialEnabled = tutorialToggle.isOn;
                    if (usernameInputFieldText.text == "" || usernameInputFieldText.text == null)
                    {
                        usernameInputFieldText.text = playerUsername;
                        GetUsername(playerUsername);
                    }
                    else
                    {
                        GetUsername(usernameInputFieldText.text);
                    }
                    SaveUsername(playerUsername, playerLanguage, RedC, OrangeC, YellowC, GreenC, BlueC, PurpleC, playerSound, playerMusic, playerTutorialEnabled, playerSwipeEnabled);
                }
            }

            credits.index = 0;
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
        if (score > 500)
        {
            if ((score - 500) / 71.43f < 35.0f) // 500 to 2500
            {
                return ((score - 500) / 71.43f);
            }
            else
            {
                return 35.0f;
            }
        }
        else
        {
            return 0.0f;
        }
    }

    public void Update()
    {
        if (gameStarting == true && startGameCounter > 0.85f)
        {
            StartGame();
            gameStarting = false;
        }
        
        startGameCounter += Time.deltaTime;

        if (musicCounter == 0) 
        {
            FindObjectOfType<AudioManager>().Play("music_menu");
            musicCounter = 1;
        }

        // Time down method timer
        if (ghostTimer > 0)
        {
            ghostTimer -= Time.deltaTime;
        }
        else
        {
            ghostTimer = 0;
        }

        // Make sure the banner ad is ALWAYS hidden when it needs to be
        if (mainMenuUI.activeInHierarchy == false && settingsUI.IsActive() == false && colourPickerUI.activeInHierarchy == false && gameOverCanvas.activeInHierarchy == false && highScoreTableUI.activeInHierarchy == false && paused == false)
        {
            //AdsManager.Instance.BannerHide();
            adController.CloseBanner();
        }

        // Sync up toggle variables with toggles
        if (tutorialToggle.isOn)
        {
            playerTutorialEnabled = true;
        }
        else
        {
            playerTutorialEnabled = false;
        }

        if (swipeToggle.isOn)
        {
            playerSwipeEnabled = true;
        }
        else
        {
            playerSwipeEnabled = false;
        }

        // Keep track of player time
        if (on == true && player.dead == false)
        {
            playerTime += Time.deltaTime;
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

        // BlockWithFistPercent
        if (((score - 1000) / 72.72f <= 55.0f)) // 1000 to 4000
        {
            blockWithFistPercent = (score - 1000) / 27.27f;
        }
        else
        {
            blockWithFistPercent = 55.0f;
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
        //gameTitleText.outlineWidth = 0;
        //gameTitleText.text = "Painted Puffin";
        startButtonText.text = language.StartButton;
        scoreButtonText.text = language.Score;
        usernameDisplayText.text = " " + playerUsername;
        comboText.text = language.Combo;

        gameOverText.text = language.GameOver;
        replayButtonText.text = language.Replay;
        continueButtonText.text = language.Continue;

        if (playerLanguage == "Latin")
        {
            if (score < 0)
            {
                scoreText.text = ToRoman(0);
            }
            else
            {
                scoreText.text = ToRoman(score);
            }
        }
        else
        {
            if (score < 0)
            {
                scoreText.text = 0.ToString();
            }
            else
            {
                scoreText.text = score.ToString();
            }
        }
        
        pauseText.text = language.Paused;

        highScoresText.text = language.HighScores;

        colourPickerText.text = language.ColourPickerText.ToUpper();

        settingsUI.text = language.Settings.ToUpper();

        swipeUI.text = language.Swipe.ToUpper();

        soundUI.text = language.Sound.ToUpper();

        musicUI.text = language.Music.ToUpper();

        tutorialUI.text = language.Tutorial.ToUpper();

        editColoursUI.text = language.ColourPickerText.ToUpper();

        if (language.Name == "" || language.Name == null)
        {
            nameFillInText.text = language.Name;
        }
        
        okButtonText.text = language.OK;
        colourSwitchOk.text = language.OK;

        if (playerLanguage == "Mandarin")
        {
            startButtonText.fontStyle = FontStyle.Normal;
            scoreButtonText.fontStyle = FontStyle.Normal;
            replayButtonText.fontStyle = FontStyle.Normal;
            continueButtonText.fontStyle = FontStyle.Normal;
            highScoresText.fontStyle = FontStyle.Normal;
            colourPickerText.fontStyle = FontStyle.Normal;
            settingsUI.fontStyle = FontStyle.Normal;
            swipeUI.fontStyle = FontStyle.Normal;
            soundUI.fontStyle = FontStyle.Normal;
            musicUI.fontStyle = FontStyle.Normal;
            tutorialUI.fontStyle = FontStyle.Normal;
            editColoursUI.fontStyle = FontStyle.Normal;
            editColoursUI.fontStyle = FontStyle.Normal;
            colourSwitchOk.fontStyle = FontStyle.Normal;
            currentLanguageDisplay.fontStyle = FontStyle.Normal;
            tutorialPaint.fontStyle = FontStyle.Normal;
            tutorialBlocks.fontStyle = FontStyle.Normal;
        }
        else
        {
            startButtonText.fontStyle = FontStyle.Bold;
            scoreButtonText.fontStyle = FontStyle.Bold;
            replayButtonText.fontStyle = FontStyle.Bold;
            continueButtonText.fontStyle = FontStyle.Bold;
            highScoresText.fontStyle = FontStyle.Bold;
            colourPickerText.fontStyle = FontStyle.Bold;
            settingsUI.fontStyle = FontStyle.Bold;
            swipeUI.fontStyle = FontStyle.Bold;
            soundUI.fontStyle = FontStyle.Bold;
            musicUI.fontStyle = FontStyle.Bold;
            tutorialUI.fontStyle = FontStyle.Bold;
            editColoursUI.fontStyle = FontStyle.Bold;
            editColoursUI.fontStyle = FontStyle.Bold;
            colourSwitchOk.fontStyle = FontStyle.Bold;
            currentLanguageDisplay.fontStyle = FontStyle.Bold;
            tutorialPaint.fontStyle = FontStyle.Bold;
            tutorialBlocks.fontStyle = FontStyle.Bold;
        }

        // Game Speed
        if (paused == false && player.dead == false)
        {
            Time.timeScale = 1.0f + (score / 9999.0f);
        }
        else if (player.dead == true)
        {
            Time.timeScale = 1.0f;
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
                PreStartGame();
            }

            if (gameOverCanvas.activeInHierarchy == true)
            {
                if (continueButtonUI.activeInHierarchy == true)
                {
                    ContinueButton();
                }
                else
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

        // Max score of 100.000
        if (score >= 100000)
        {
            score = 100000;
            ClearObstacles();
            canContinue = false;
            player.KillPlayer();
        }
    }

    
    public void AssignLocationData()
    {
        {

        }
    }

    // Collect and assign location data if permission is granted
    IEnumerator CollectAndAssignLocation()
    {
        if (AndroidRuntimePermissions.CheckPermission("android.permission.ACCESS_FINE_LOCATION") == AndroidRuntimePermissions.Permission.Granted)
        {
            UnityWebRequest request = UnityWebRequest.Get("https://extreme-ip-lookup.com/json");
            request.chunkedTransfer = false;
            yield return request.SendWebRequest();

            if (request.isNetworkError)
            {
                Debug.Log("Location Collection Error: " + request.error);
            }
            else
            {
                if (request.isDone)
                {
                    LocationData res = JsonUtility.FromJson<LocationData>(request.downloadHandler.text);
                    playerRegion = res.region;

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
                        playerCountry = res.countryCode;
                    }

                    playerCity = res.city;
                    Debug.Log(playerCountry += "_" + playerCity + "-" + playerRegion);
                }
            }
        }
        else
        {
            // Permission is not granted
            Debug.Log("XX_Denied");
        }
    }

    // Display game over overlay and upload high score when the player dies
    public void GameOver()
    {
        // Ad
        //AdsManager.Instance.BannerShow();
        adController.ShowBanner();

        gameOverCanvas.SetActive(true);
        FindObjectOfType<AudioManager>().Play("deathjingle");
        if (canContinue == false)
        {
            continueButtonUI.SetActive(false);
        }
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
        //AdsManager.Instance.BannerHide();
        //AdsManager.Instance.ShowInterstitial();
        //adController.CloseBanner();
        //reward2.ShowId();
        ContinueButton2();
    }

    public void ContinueButton2()
    {
        player.dead = false;
        player.rb.gravityScale = 0;
        player.rb.MovePosition(new Vector2(-1.0f, -0.075f));
        uploadScoreUI.sprite = null;
        uploadScoreUI.color = new Color(1, 1, 1, 0f);
        on = false;
        ClearObstacles();
        if (player.colour == 7)
        {
            player.colour = 0;
        }
        canContinue = false;
        player.position = "ready";
        player.StartWalking();
        gameOverCanvas.SetActive(false);
        player.SwitchGameOn();
        FindObjectOfType<AudioManager>().Play("music_game");
    }

    // Colour picker
    public void OKButtonCP()
    {
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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
        FindObjectOfType<AudioManager>().Play("click");
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

    // Hyperlinks
    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/its_xommon/");
    }
}

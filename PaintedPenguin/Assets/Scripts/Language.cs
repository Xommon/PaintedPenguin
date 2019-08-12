using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    // References
    public GameManager gameManager;
    
    // Main Menu
    public string GameTitle;
    public string Start;
    public string Score;
    public string HelloUsername;

    // Game Over
    public string GameOver;
    public string Replay;
    public string Continue;

    // Score
    public string ScoreUI;

    // Pause
    public string Paused;

    // High Scores
    public string HighScores;

    // Username Input
    public string Name;
    public string OK;
    public string Warning1;
    public string Warning2;
    public Button Flag;

    // Flags
    public Sprite english;
    public Sprite french;
    public Sprite mandarin;
    public Sprite cantonese;
    public Sprite german;
    public Sprite spanish;
    public Sprite italian;
    public Sprite portuguese;
    public Sprite russian;
    public Sprite ukranian;
    public Sprite greek;
    public Sprite turkish;
    public Sprite danish;
    public Sprite swedish;
    public Sprite norwegian;
    public Sprite dutch;
    public Sprite polish;
    public Sprite finnish;
    public Sprite japanese;
    public Sprite korean;
    public Sprite czech;
    public Sprite hungarian;
    public Sprite romanian;
    public Sprite thai;
    public Sprite bulgarian;
    public Sprite hebrew;
    public Sprite arabic;
    public Sprite bosnian;
    public Sprite vietnamese;
    public Sprite latin;
    public Sprite icelandic;
    public Sprite catalonian;
    public Sprite inuit;

    // Languages
    public void English()
    {
        // Main Menu
        GameTitle = "Painted Penguin";
        Start = "START";
        Score = "SCORE";
        HelloUsername = "Hello, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "GAME OVER";
        Replay = "REPLAY";
        Continue = "CONTINUE?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "PAUSED";

        // High Scores
        HighScores = "HIGH SCORES";

        // Username Input
        Name = "Name ...";
        OK = "OK";
        Warning1 = "Cannot contain spaces or *.";
        Warning2 = "Must be between 1 and 12 characters.";
        Flag.GetComponent<Image>().sprite = Resources.Load<Sprite>("flags/gb.gif");
    }

    public void French()
    {
        // Main Menu
        GameTitle = "Macareux Peint";
        Start = "DÉBUT";
        Score = "SCORES";
        HelloUsername = "Bonjour, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "JEU TERMINÉ";
        Replay = "REJOUER";
        Continue = "CONTINUER?";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "EN PAUSE";

        // High Scores
        HighScores = "SCORES ÉLEVÉS";

        // Username Input
        Name = "Nom ...";
        OK = "D'accord";
        Warning1 = "Ne peut pas contenir d'espaces ou *.";
        Warning2 = "Doit comporter entre 1 et 12 caractères.";
        Flag.image.sprite = french;
    }

    public void Mandarin()
    {
        // Main Menu
        GameTitle = "画海雀";
        Start = "开始";
        Score = "高分数";
        HelloUsername = "你好, " + gameManager.playerUsername + "！";

        // Game Over
        GameOver = "游戏结束";
        Replay = "重播";
        Continue = " 继续？";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "暂停";

        // High Scores
        HighScores = "高分数";

        // Username Input
        Name = "你的名字 。。。";
        OK = "好";
        Warning1 = "不能包含空格或“*”。";
        Warning2 = "必须介于1到12个字符之间。";
        Flag.image.overrideSprite = mandarin;
    }

    public void Cantonese()
    {
        // Main Menu
        GameTitle = "彩繪松餅";
        Start = "初時";
        Score = "高分";
        HelloUsername = "你好, " + gameManager.playerUsername + "！";

        // Game Over
        GameOver = "遊戲結束";
        Replay = "重播";
        Continue = " 繼續？";

        // Score
        ScoreUI = gameManager.score.ToString();

        // Pause
        Paused = "暫停";

        // High Scores
        HighScores = "高分";

        // Username Input
        Name = "名字 。。。";
        OK = "仲可以";
        Warning1 = "唔包含空格或“*”。";
        Warning2 = "必須介乎1到12個字符之間。";
        Flag.image.overrideSprite = cantonese;
    }

    public void Latin()
    {
        // Main Menu
        GameTitle = "Painted Puffin";
        Start = "Initium";
        Score = "Gradus";
        HelloUsername = "Salve, " + gameManager.playerUsername + "!";

        // Game Over
        GameOver = "FINIS";
        Replay = "SILEO";
        Continue = " RESUMO?";

        // Score
        ScoreUI = toRoman(gameManager.score);

        // Pause
        Paused = "PAULUM";

        // High Scores
        HighScores = "GRADUS";

        // Username Input
        Name = "Nomen ...";
        OK = "OK";
        Warning1 = "Non habet spatia vel *";
        Warning2 = "XII et I oportet inter ingenia.";
        Flag.image.overrideSprite = latin;
    }

    public string toRoman(int score)
    {
        if (score >= 1000) return "Ⅿ" + toRoman(score - 1000);
        if (score >= 900) return "ⅭⅯ" + toRoman(score - 900);
        if (score >= 500) return "Ⅾ" + toRoman(score - 500);
        if (score >= 400) return "ⅭⅮ" + toRoman(score - 400);
        if (score >= 100) return "Ⅽ" + toRoman(score - 100);
        if (score >= 90) return "ⅩⅭ" + toRoman(score - 90);
        if (score >= 50) return "Ⅼ" + toRoman(score - 50);
        if (score >= 40) return "ⅩⅬ" + toRoman(score - 40);
        if (score >= 10) return "Ⅹ" + toRoman(score - 10);
        if (score >= 9) return "Ⅸ" + toRoman(score - 9);
        if (score >= 5) return "Ⅴ" + toRoman(score - 5);
        if (score >= 4) return "Ⅳ" + toRoman(score - 4);
        if (score >= 1) return "Ⅰ" + toRoman(score - 1);
        return "";
    }
}

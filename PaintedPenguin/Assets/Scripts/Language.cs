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
    public string Loading;

    // Username Input
    public string Name;
    public string OK;
    public string Warning1;
    public string Warning2;

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
        Loading = "Loading ...";

        // Username Input
        Name = "Name ...";
        OK = "OK";
        Warning1 = "Cannot contain spaces or *.";
        Warning2 = "Must be between 1 and 12 characters.";
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
        Loading = "Chargement ...";

        // Username Input
        Name = "Nom ...";
        OK = "D'accord";
        Warning1 = "Ne peut pas contenir d'espaces ou *.";
        Warning2 = "Doit comporter entre 1 et 12 caractères.";
    }
}

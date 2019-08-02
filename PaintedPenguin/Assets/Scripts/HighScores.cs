using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScores : MonoBehaviour
{
    // http://dreamlo.com/lb/cQ87T8a7BUGRQmQNMDB6iwWUTDoSubyUOyfJ9_43b3_g

    const string privateCode = "cQ87T8a7BUGRQmQNMDB6iwWUTDoSubyUOyfJ9_43b3_g";
    const string publicCode = "5d43646f76827f1758cfaa7c";
    const string webURL = "http://dreamlo.com/lb/";

    void Start()
    {
        AddNewHighScore("Micheal", 100);
        AddNewHighScore("Julia", 150);
        AddNewHighScore("Troy", 129);
    }

    public void AddNewHighScore(string username, int score)
    {
        StartCoroutine(UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
        } else
        {
            print("Error uploading: " + www.error);
        }
    }
}

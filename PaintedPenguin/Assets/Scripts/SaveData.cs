using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
    public string playerUsername;
    public string playerLanguage;
    public string playerRed;
    public string playerOrange;
    public string playerYellow;
    public string playerGreen;
    public string playerBlue;
    public string playerPurple;
    public float playerSound;
    public float playerMusic;
    //public bool playerTutorialEnabled;

    public SaveData (GameManager gameManager)
    {
        playerUsername = gameManager.playerUsername;
        playerLanguage = gameManager.playerLanguage;
        playerRed = gameManager.ColourToHex(gameManager.RedC);
        playerOrange = gameManager.ColourToHex(gameManager.OrangeC);
        playerYellow = gameManager.ColourToHex(gameManager.YellowC);
        playerGreen = gameManager.ColourToHex(gameManager.GreenC);
        playerBlue = gameManager.ColourToHex(gameManager.BlueC);
        playerPurple = gameManager.ColourToHex(gameManager.PurpleC);
        playerSound = gameManager.playerSound;
        playerMusic = gameManager.playerMusic;
        //playerTutorialEnabled = gameManager.playerTutorialEnabled;
    }
}

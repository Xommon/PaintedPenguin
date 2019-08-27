using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string playerUsername;
    public string playerLanguage;
    //public Color playerRed;
    //public Color playerOrange;
    //public Color playerYellow;
    //public Color playerGreen;
    //public Color playerBlue;
    //public Color playerPurple;


    public SaveData (GameManager gameManager)
    {
        playerUsername = gameManager.playerUsername;
        playerLanguage = gameManager.playerLanguage;
        //playerRed = gameManager.RedC;
        //playerOrange = gameManager.OrangeC;
        //playerYellow = gameManager.YellowC;
        //playerGreen = gameManager.GreenC;
        //playerBlue = gameManager.BlueC;
        //playerPurple = gameManager.PurpleC;
    }
}

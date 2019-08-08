using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public string playerUsername;

    public SaveData (GameManager gameManager)
    {
        playerUsername = gameManager.playerUsername;
    }
}

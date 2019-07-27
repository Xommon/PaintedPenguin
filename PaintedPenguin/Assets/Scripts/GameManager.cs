using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public int score;

    public void Start()
    {
        Time.timeScale = 1;
        score = 0;
    }

    public void Update()
    {
        if (gameOverCanvas.activeInHierarchy == true)
        {
            Time.timeScale -= 0.05f;
        }
    }

    //Display game over overlay when the player dies
    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        //Time.timeScale = 0.5f;
    }

}

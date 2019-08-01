﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Menu components
    public GameObject gameOverCanvas;
    public GameObject continueButtonUI;
    public GameObject mainMenuUI;
    public GameObject gameUI;
    public AdController adController;

    // Game components
    public bool on;
    public int score;
    public float maxTime2 = 1;
    public PlayerMovement player;
    public bool canContinue;

    // Obstacle creation
    public float maxTime = 1;
    private float timer = 0;
    public GameObject block;
    public GameObject paint;
    float place;
    float place2;
    public float obstacleSpeed;
    public List<float> obstaclePositions = new List<float>();

    public bool PercentChance(int percent)
    {
        int selection = Random.Range(0, 101);
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
        if (timer > maxTime)
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
            if (PercentChance(10))
            {
                GameObject newpaint = Instantiate(paint);
                newpaint.transform.position = transform.position + new Vector3(1, obstaclePositions[0], 0);
            }

            // Increase score every second
            score += 1;
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    public void Start()
    {
        adController.OpenBannerAd();
        mainMenuUI.SetActive(true);
        canContinue = true;
        Time.timeScale = 1;
        score = 0;
    }

    // Start Button pressed
    public void StartGame()
    {
        adController.CloseAd();
        player.position = "starting";
        mainMenuUI.SetActive(false);
        gameUI.SetActive(true);
    }

    // Score Button pressed
    public void ScoreButton()
    {
        // ONLINE HIGH SCORE LIST
    }

    public void Update()
    {
        // Obstacles
        if (on == true && player.dead == false)
        {
            SpawnBlock();
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
        }
    }

    //Display game over overlay when the player dies
    public void GameOver()
    {
        adController.OpenBannerAd();
        gameOverCanvas.SetActive(true);
        if (canContinue == false)
        {
            continueButtonUI.SetActive(false);
        }
    }

    public void RestartGame()
    {
        adController.CloseAd();
        SceneManager.LoadScene("SampleScene");
    }

    public void ContinueButton()
    {
        adController.OpenRewardedVideoAd();
        Time.timeScale = 1f;
        player.dead = false;
        gameOverCanvas.SetActive(false);
        player.position = "starting";
        canContinue = false;
    }
}

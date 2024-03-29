﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LoadingBar : MonoBehaviour
{
    public Transform loadingBarValue;
    public GameObject circleLoadingBar;
    public PlayerMovement player;
    public Image selfImage;
    public TMP_Text visualMultiplier;
    public Image tinyMagnet;
    public Image outline;
    public bool exists;
    public float currentAmount;
    public float speed;
    public bool soundPlayed;
    public float timer;

    void Start()
    {
        soundPlayed = false;
        currentAmount = 100;
        timer = 0;
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (player.timesTwoMode != 1)
        {
            visualMultiplier.text = "×" + player.timesTwoMode;
        }

        if (player.colour != 7)
        {
            speed = 4;
        }
        else
        {
            speed = 8;
        }

        if (currentAmount > 0)
        {
            currentAmount -= speed * Time.deltaTime;
            timer -= Time.deltaTime * 60;

            if (timer <= 0)
            {
                FindObjectOfType<AudioManager>().Play("tick");
                if (currentAmount >= 7)
                {
                    timer = Mathf.RoundToInt(currentAmount);
                }
                else
                {
                    timer = 7;
                }
            }
        }
        else
        {
            player.timesTwoMode = 1;
            player.magnet = false;
            player.comboStreak = 0;
            if (player.colour == 7)
            {
                player.colour = 0;
            }
            player.flashing = false;
            FindObjectOfType<AudioManager>().Play("timesup");

            Destroy(transform.parent.gameObject);
        }

        if (player.magnet == true)
        {
            tinyMagnet.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            tinyMagnet.transform.localScale = new Vector3(0, 0, 0);
        }

        loadingBarValue.GetComponent<Image>().fillAmount = currentAmount / 100;
        outline.GetComponent<Image>().fillAmount = currentAmount / 100;

        gameObject.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0.2f, 0, 0));
        
        if (player.colour != 0)
        {
            selfImage.color = new Color(player.sr.color.r, player.sr.color.g, player.sr.color.b, 0.75f);
        }
        else
        {
            // Colourless colour
            selfImage.color = new Color(player.sr.color.r, player.sr.color.g, player.sr.color.b, 0f);
        }
    }
}

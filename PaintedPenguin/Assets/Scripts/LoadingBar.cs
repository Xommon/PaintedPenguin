using System.Collections;
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
    public bool exists;
    public float currentAmount;
    public float speed;
    public bool soundPlayed;

    void Start()
    {
        soundPlayed = false;
        currentAmount = 100;
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
            speed = 6;
        }
        else
        {
            speed = 12;
        }

        if (currentAmount > 0)
        {
            currentAmount -= speed * Time.deltaTime;
        }
        else
        {
            player.timesTwoMode = 1;
            if (player.colour == 7)
            {
                player.colour = 0;
            }

            Destroy(transform.parent.gameObject);
        }

        loadingBarValue.GetComponent<Image>().fillAmount = currentAmount / 100;

        gameObject.transform.position = Camera.main.WorldToScreenPoint(player.transform.position + new Vector3(0.25f, 0, 0));
        
        selfImage.color = new Color(player.sr.color.r, player.sr.color.g, player.sr.color.b, 0.6f);
    }
}

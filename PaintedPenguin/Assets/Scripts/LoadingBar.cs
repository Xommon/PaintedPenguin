using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LoadingBar : MonoBehaviour
{
    public Transform loadingBarValue;
    public GameObject circleLoadingBar;
    public PlayerMovement player;
    public Image selfImage;
    public bool exists;
    public float currentAmount;
    public float speed;

    void Start()
    {
        currentAmount = 100;
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (player.timesTwoMode > 1)
        {
            speed = 6;
        }
        else if (player.colour == 7)
        {
            speed = 12;
        }

        if (currentAmount > 0)
        {
            currentAmount -= speed * Time.deltaTime;
        } else
        {
            if (player.timesTwoMode > 1)
            {
                player.timesTwoMode = 1;
            }
            else
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

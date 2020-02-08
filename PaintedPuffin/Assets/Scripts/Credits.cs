using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Credits : MonoBehaviour
{
    public TMP_Text topText;
    public TMP_Text bottomText;
    public List<string> topTexts = new List<string>();
    public List<string> bottomTexts = new List<string>();
    public float count;
    public int index;
    public bool creditsEnabled;
    public GameObject mainMenu;

    public TMP_FontAsset latin;
    public TMP_FontAsset simplifiedChinese;
    
    void Start()
    {
        creditsEnabled = true;

        count = 0;

        bottomTexts.Add("micheal quentin");
        bottomTexts.Add("chris ambroziak");
        bottomTexts.Add("patrick de arteaga");
        bottomTexts.Add("vicente nitti");
        bottomTexts.Add("icons8.com");
        bottomTexts.Add("jeff portaro");
        bottomTexts.Add("freesounds.org");
        
        bottomText.text = bottomTexts[0];
    }
    
    void Update()
    {
        if (index == 0)
        {
            topText.text = topTexts[0];
            bottomText.text = bottomTexts[0];
        }

        if (FindObjectOfType<GameManager>().playerLanguage == "Mandarin")
        {
            topText.font = simplifiedChinese;
            topText.fontStyle = FontStyles.Normal;
        }
        else
        {
            topText.font = latin;
            topText.fontStyle = FontStyles.Bold;
        }

        if (creditsEnabled == true && FindObjectOfType<GameManager>().settingsUI.IsActive() == false)
        {
            count += Time.deltaTime;

            if (count >= 6)
            {
                if (index >= topTexts.Count - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
                count = 0;
                topText.text = topTexts[index];
                bottomText.text = bottomTexts[index];
            }
        }
        else
        {
            index = 0;
            count = 0;
        }
    }
}

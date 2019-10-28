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
    
    void Start()
    {
        creditsEnabled = true;

        count = 0;

        bottomTexts.Add("micheal quentin");
        bottomTexts.Add("chris ambroziak");
        bottomTexts.Add("vicente nitti");
        bottomTexts.Add("https://icons8.com");
        bottomTexts.Add("jeff portaro");

        topText.text = topTexts[0];
        bottomText.text = bottomTexts[0];
    }
    
    void Update()
    {
        if (creditsEnabled == true)
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
    }
}

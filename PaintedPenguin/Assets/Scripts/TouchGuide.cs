using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchGuide : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject floatingText;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 4.0f);
        Invoke("GoActive", 3.5f);
    }

    public void GoActive()
    {
        GameObject newText = Instantiate(floatingText);
        newText.GetComponent<TextMeshPro>().text = "GO!!";
        newText.GetComponent<TextMeshPro>().transform.position += new Vector3(0, 0.33f, 0);
        Destroy(newText, 1.0f);
    }

    public void DestroySelf()
    {
        gameManager.playerTutorialEnabled = false;
        //gameManager.SaveUsername(gameManager.playerUsername, gameManager.playerLanguage, gameManager.RedC, gameManager.OrangeC, gameManager.YellowC, gameManager.GreenC, gameManager.BlueC, gameManager.PurpleC, gameManager.playerSound, gameManager.playerMusic, false);
        //Destroy(go);
        Destroy(gameObject);
    }
}

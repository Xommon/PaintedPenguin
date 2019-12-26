using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchGuide : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject floatingText;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", 4.0f);
    }

    public void DestroySelf()
    {
        gameManager.playerTutorialEnabled = false;
        Destroy(gameObject);
    }
}

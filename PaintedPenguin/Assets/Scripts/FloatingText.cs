using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public TextMeshPro floatingText;
    public PlayerMovement player;
    public GameManager gameManager;

    void Update()
    {
        transform.position += Vector3.up * 0.5f * Time.deltaTime;
        //floatingText.text = "5";
    }
}

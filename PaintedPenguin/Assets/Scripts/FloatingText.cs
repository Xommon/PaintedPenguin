using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public TextMeshPro floatingText;
    public PlayerMovement player;
    public GameManager gameManager;
    public float verticalSpeed;
    public float horizontalSpeed;

    void Update()
    {
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
        transform.position += Vector3.right * horizontalSpeed * Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameManager gameManager;
    public int colour;
    public SpriteRenderer sr;
    public bool hit = false;
    public float moving;
    public float moveMax;
    public float moveMin;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // Set price
        int price = Random.Range(1, 4);

        // Randomly choose paint's colour
        int roll = Random.Range(1, 7); // Between 1 and 6
        if (roll == 1)
        {
            // Red
            colour = 1;
            sr.color = gameManager.RedC;
        }
        if (roll == 2)
        {
            // Orange
            colour = 2;
            sr.color = gameManager.OrangeC;
        }
        if (roll == 3)
        {
            // Yellow
            colour = 3;
            sr.color = gameManager.YellowC;
        }
        if (roll == 4)
        {
            // Green
            colour = 4;
            sr.color = gameManager.GreenC;
        }
        if (roll == 5)
        {
            // Blue
            colour = 5;
            sr.color = gameManager.BlueC;
        }
        if (roll == 6)
        {
            // Purple
            colour = 6;
            sr.color = gameManager.PurpleC;
        }
    }

    void Update()
    {
        // Blocks keep moving to the left
        transform.position += Vector3.left * 0.75f * Time.deltaTime;

        // Blocks move up and down
        transform.position += Vector3.up * moving * 1.0f * Time.deltaTime;

        // Destroy if out of scene
        if (transform.position.x < -0.9)
        {
            GameObject.Destroy(gameObject);
        }

        if (moveMax != 0 && moveMin != 0)
        {
            if (gameObject.transform.position.y >= moveMax)
            {
                moving *= -1;
            }

            if (gameObject.transform.position.y <= moveMin)
            {
                moving *= -1;
            }
        }
    }
}

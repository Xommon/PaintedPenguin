using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
    public GameManager gameManager;
    public int colour;
    public SpriteRenderer sr;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

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

    // Update is called once per frame
     void Update()
    {
        // Move toward player if magnet powerup is enabled
        if (FindObjectOfType<PlayerMovement>().magnet == true && transform.position.x < 0.5)
        {
            transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<PlayerMovement>().transform.position, 0.03f);
        }
        else
        {
            // Paint keeps moving to the left
            transform.position += Vector3.left * 0.75f * Time.deltaTime;
        }

        // Destroy if out of scene
        if (transform.position.x < -0.9)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

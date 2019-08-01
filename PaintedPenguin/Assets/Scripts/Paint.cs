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
        // Randomly choose paint's colour
        int roll = Random.Range(1, 7); // Between 1 and 6
        if (roll == 1)
        {
            // Red
            colour = 1;
            sr.color = new Color(1f, 0.1f, 0.1f, 1f);
        }
        if (roll == 2)
        {
            // Orange
            colour = 2;
            sr.color = new Color(1f, 0.5f, 0.1f, 1f);
        }
        if (roll == 3)
        {
            // Yellow
            colour = 3;
            sr.color = new Color(1f, 1f, 0.1f, 1f);
        }
        if (roll == 4)
        {
            // Green
            colour = 4;
            sr.color = new Color(0.1f, 1f, 0.1f, 1f);
        }
        if (roll == 5)
        {
            // Blue
            colour = 5;
            sr.color = new Color(0.1f, 0.2f, 1f, 1f);
        }
        if (roll == 6)
        {
            // Purple
            colour = 6;
            sr.color = new Color(0.7f, 0.1f, 1f, 1f);
        }
    }



    // Update is called once per frame
    void Update()
    {
        // Paint keeps moving to the left
        transform.position += Vector3.left * gameManager.obstacleSpeed * Time.deltaTime;

        // Destroy if out of scene
        if (transform.position.x < -0.9)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

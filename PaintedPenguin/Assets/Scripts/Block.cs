using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameManager gameManager;
    public int colour;
    public int colour2;
    public SpriteRenderer sr;
    public SpriteRenderer sr2;
    public bool hit = false;
    public float moving;
    public float moveMax;
    public float moveMin;
    public List<int> colours = new List<int>();

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        colours.Add(1);
        colours.Add(2);
        colours.Add(3);
        colours.Add(4);
        colours.Add(5);
        colours.Add(6);

        // Randomly choose block's colour
        int roll = Random.Range(1, 7); // Between 1 and 6
        if (roll == 1)
        {
            // Red
            colour = 1;
            colours.Remove(1);
            sr.color = gameManager.RedC;
        }
        if (roll == 2)
        {
            // Orange
            colour = 2;
            colours.Remove(2);
            sr.color = gameManager.OrangeC;
        }
        if (roll == 3)
        {
            // Yellow
            colour = 3;
            colours.Remove(3);
            sr.color = gameManager.YellowC;
        }
        if (roll == 4)
        {
            // Green
            colour = 4;
            colours.Remove(4);
            sr.color = gameManager.GreenC;
        }
        if (roll == 5)
        {
            // Blue
            colour = 5;
            colours.Remove(5);
            sr.color = gameManager.BlueC;
        }
        if (roll == 6)
        {
            // Purple
            colour = 6;
            colours.Remove(6);
            sr.color = gameManager.PurpleC;
        }

        if (gameObject.name == "BlockWithPaint(Clone)")
        {
            int roll2 = Random.Range(0, 5);
            colour2 = colours[roll2];

            if (colour2 == 1)
            {
                sr2.color = gameManager.RedC;
            }
            if (colour2 == 2)
            {
                sr2.color = gameManager.OrangeC;
            }
            if (colour2 == 3)
            {
                sr2.color = gameManager.YellowC;
            }
            if (colour2 == 4)
            {
                sr2.color = gameManager.GreenC;
            }
            if (colour2 == 5)
            {
                sr2.color = gameManager.BlueC;
            }
            if (colour2 == 6)
            {
                sr2.color = gameManager.PurpleC;
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public GameManager gameManager;
    public SpriteRenderer sr;
    public bool hit = false;
    public float moving;
    public float moveMax;
    public float moveMin;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (Time.timeScale != 0)
        {
            transform.Rotate(0, 0, 5);
        } else
        {
            transform.Rotate(0, 0, 0);
        }

        // SpikeBalls keep moving to the left
        transform.position += Vector3.left * 0.75f * Time.deltaTime;

        // SpikeBalls move up and down
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

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Block(Clone)")
        {
            Destroy(collision.gameObject);
        }

        if (collision.transform.name == "Paint(Clone)")
        {
            Destroy(collision.gameObject);
        }

        if (collision.transform.name == "Rainbow(Clone)")
        {
            Destroy(collision.gameObject);
        }

        if (collision.transform.name == "TimesTwo(Clone)")
        {
            Destroy(collision.gameObject);
        }

        if (collision.transform.name == "TimesThree(Clone)")
        {
            Destroy(collision.gameObject);
        }
    }
}

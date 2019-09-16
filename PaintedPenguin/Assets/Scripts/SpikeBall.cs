using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBall : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement player;
    public SpriteRenderer sr;
    public bool hit = false;
    public float moving;
    public float moveMax;
    public float moveMin;
    public ParticleSystem blockBurst;
    public ParticleSystem dustBurst;
    public ParticleSystem paintBurst;

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
        if (collision.transform.name != "Player")
        {
            if (collision.transform.tag == "Block")
            {
                ParticleSystem ps = Instantiate(blockBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ParticleSystem ps2 = Instantiate(dustBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ps.startColor = collision.gameObject.GetComponent<Block>().sr.color;
                Destroy(ps.gameObject, ps.startLifetime);
                Destroy(ps2.gameObject, ps2.startLifetime);
            }
            else if (collision.transform.tag == "Paint")
            {
                ParticleSystem ps3 = Instantiate(paintBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ps3.startColor = collision.gameObject.GetComponent<Paint>().sr.color;
                Destroy(ps3.gameObject, ps3.startLifetime);
            }
            else if (collision.transform.tag == "Rainbow")
            {
                ParticleSystem ps3 = Instantiate(paintBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ps3.startColor = sr.color;
                Destroy(ps3.gameObject, ps3.startLifetime);
            }
            Destroy(collision.gameObject);
        }
    }
}

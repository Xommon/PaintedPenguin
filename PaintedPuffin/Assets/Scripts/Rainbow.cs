using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public GameManager gameManager;
    public SpriteRenderer sr;
    public BoxCollider2D bc;

    private void Start()
    {
        if (FindObjectOfType<PlayerMovement>().magnet == false)
        {
            bc.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Move toward player if magnet powerup is enabled
        if (FindObjectOfType<PlayerMovement>().magnet == true && transform.position.x < 0.5)
        {
            transform.position = Vector3.MoveTowards(transform.position, FindObjectOfType<PlayerMovement>().transform.position, Time.deltaTime);
            bc.enabled = false;
        }
        else
        {
            // Paint keeps moving to the left
            transform.position += Vector3.left * 0.75f * Time.deltaTime;
        }

        if (transform.position == FindObjectOfType<PlayerMovement>().transform.position)
        {
            ParticleSystem ps3 = Instantiate(FindObjectOfType<PlayerMovement>().paintBurst, transform.position, Quaternion.identity) as ParticleSystem;
            ps3.startColor = FindObjectOfType<PlayerMovement>().sr.color;
            Destroy(ps3.gameObject, ps3.startLifetime);
            FindObjectOfType<AudioManager>().Play("bubble");

            if (FindObjectOfType<PlayerMovement>().colour != 7 && FindObjectOfType<PlayerMovement>().dead == false)
            {
                FindObjectOfType<PlayerMovement>().colour = 7;
                FindObjectOfType<PlayerMovement>().Rainbow();
                FindObjectOfType<AudioManager>().Play("powerup");
            }

            Destroy(gameObject);
        }

        if (Vector3.Distance(FindObjectOfType<PlayerMovement>().transform.position, transform.position) < 0.08628588)
        {
            bc.enabled = true;
        }
        else
        {
            bc.enabled = false;
        }

        // Destroy if out of scene
        if (transform.position.x < -0.9)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

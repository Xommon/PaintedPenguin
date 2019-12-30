using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesTwo : MonoBehaviour
{
    public CircleCollider2D bc;

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
            // Powerup keeps moving to the left
            transform.position += Vector3.left * 0.75f * Time.deltaTime;
        }

        if (transform.position == FindObjectOfType<PlayerMovement>().transform.position)
        {
            if (FindObjectOfType<PlayerMovement>().dead == false)
            {
                Instantiate(FindObjectOfType<PlayerMovement>().blockPop, transform.position, Quaternion.identity);
                FindObjectOfType<PlayerMovement>().timesTwoMode *= 2;
                FindObjectOfType<PlayerMovement>().TimesTwoMode();
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

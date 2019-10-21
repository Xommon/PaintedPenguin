using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesTwo : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Paint keeps moving to the left
        transform.position += Vector3.left * 0.75f * Time.deltaTime;

        // Move toward player if magnet powerup is enabled
        if (FindObjectOfType<PlayerMovement>().magnet == true && transform.position.x < 0.5)
        {
            transform.position = new Vector2(transform.position.x, FindObjectOfType<PlayerMovement>().transform.position.y);
            transform.position += new Vector3(0.1f * Time.deltaTime, 0, 0);
        }

        // Destroy if out of scene
        if (transform.position.x < -0.9)
        {
            GameObject.Destroy(gameObject);
        }
    }
}

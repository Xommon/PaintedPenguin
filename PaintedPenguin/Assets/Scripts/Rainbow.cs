using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rainbow : MonoBehaviour
{
    public GameManager gameManager;

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

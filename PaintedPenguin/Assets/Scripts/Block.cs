using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    public PlayerMovement player;

    void Update()
    {
        //Blocks only move if the player is alive
        if (player.dead != true)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            //transform.position = Vector3.zero * speed * Time.deltaTime;
        }

        Debug.Log(player.dead);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.name == "Player")
        {
            player.dead = true;
            Debug.Log("Hit player");
        }
    }
}

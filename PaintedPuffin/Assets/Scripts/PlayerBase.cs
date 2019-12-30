using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public PlayerMovement player;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        if (player.position == "ready")
        {
            // Player is out of sight, ready to start
            animator.SetBool("jumping", false);
            animator.SetBool("falling", false);
            animator.SetBool("swimming", false);
            animator.SetBool("dead", false);
        }

        // Player walks to starting position
        if (player.position == "starting" && player.dead == false)
        {
            animator.SetBool("dead", false);
        }

        if (player.dead == false)
        {
            // Snap to ground if walking
            if (player.rb.position.y != -0.075 && player.position == "walking")
            {
                animator.SetBool("jumping", false);
                animator.SetBool("falling", false);
                animator.SetBool("swimming", false);
            }

            // Player starts walking if it falls to the ground or resurfaces from water
            if ((player.rb.position.y <= -0.010 && player.position == "falling") || ((player.rb.position.y >= -0.140) && player.position == "resurfacing"))
            {
                animator.SetBool("falling", false);
                animator.SetBool("swimming", false);

            }

            // Mark player as falling
            if (player.position == "jumping" && player.rb.velocity.y < -0.1)
            {
                animator.SetBool("jumping", false);
                animator.SetBool("falling", true);
            }
        }
    }
}

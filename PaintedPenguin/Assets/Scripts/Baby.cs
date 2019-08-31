using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement player;
    public GameManager gameManager;
    public int babyValue;

    void Start()
    {
        if (gameObject.name == "Baby")
        {
            babyValue = 1;
            animator.SetInteger("Baby", babyValue);
        }

        if (gameObject.name == "Baby2")
        {
            babyValue = 2;
            animator.SetInteger("Baby", babyValue);
        }

        if (gameObject.name == "Baby3")
        {
            babyValue = 3;
            animator.SetInteger("Baby", babyValue);
        }

        if (player.position == "walking")
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Swimming", false);

            if (gameObject.name == "Baby")
            {
                animator.SetInteger("Baby", babyValue);
            }

            if (gameObject.name == "Baby2")
            {
                animator.SetInteger("Baby", babyValue);
            }

            if (gameObject.name == "Baby3")
            {
                animator.SetInteger("Baby", babyValue);
            }
        }

        if (player.position == "jumping")
        {
            animator.SetBool("Jumping", true);
        }

        if (player.position == "diving")
        {
            animator.SetBool("Swimming", true);
        }

    }
    
    void Update()
    {
        if (gameManager.paused == false && player.playerPositions.Count > 98)
        {
            transform.position = player.playerPositions[45 + (15 * babyValue)] - new Vector2(0.28f - (0.06f * babyValue), 0.07f);
        }
    }
}

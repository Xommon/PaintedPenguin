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
        animator.SetInteger("Baby", babyValue);

        if (player.position == "walking")
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Swimming", false);
        }

        if (player.position == "jumping")
        {
            animator.SetBool("Jumping", true);
            animator.SetBool("Swimming", false);
        }

        if (player.position == "diving")
        {
            animator.SetBool("Swimming", true);
            animator.SetBool("Jumping", false);
        }

    }
    
    void Update()
    {
        if (gameManager.paused == false && player.playerPositions.Count > (45 + (15 * babyValue)))
        {
            transform.position = player.playerPositions[45 + (15 * babyValue)] - new Vector2(0.28f - (0.06f * babyValue), 0.07f);
        }
    }
}

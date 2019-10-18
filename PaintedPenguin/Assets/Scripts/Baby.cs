using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement player;
    public GameManager gameManager;
    public Rigidbody2D rigidBody;
    public int babyValue;

    void Start()
    {
        animator.SetInteger("Baby", babyValue);
    }
    
    void Update()
    {
        if (gameManager.paused == false && player.playerPositions.Count > (25 + (15 * babyValue)))
        {
            //if (player.playerPositions2[45 + (15 * babyValue)] != "walking")
            {
                transform.position = player.playerPositions[25 + (15 * babyValue)] - new Vector2(0.28f - (0.06f * babyValue), 0.07f);
            }

            if (player.playerPositions2[25 + (15 * babyValue)] == "walking")
            {
                animator.SetBool("Jumping", false);
                animator.SetBool("Swimming", false);
                animator.SetBool("Dead", false);


            }
            else if (player.playerPositions2[25 + (15 * babyValue)] == "jumping")
            {
                animator.SetBool("Jumping", true);
                animator.SetBool("Swimming", false);
                animator.SetBool("Dead", false);
            }
            else if (player.playerPositions2[25 + (15 * babyValue)] == "diving")
            {
                animator.SetBool("Swimming", true);
                animator.SetBool("Jumping", false);
                animator.SetBool("Dead", false);
            }
            else if (player.playerPositions2[25 + (15 * babyValue)] == "dead")
            {
                animator.SetBool("Swimming", false);
                animator.SetBool("Jumping", false);
                animator.SetBool("Dead", true);
            }
        }

        if (babyValue == 1)
        {
            //if (player.playerPositions2[45 + (15 * babyValue)] == "walking")
            {
                //transform.position = new Vector2(-0.49f, -0.1454418f);
            }
        }
    }
}

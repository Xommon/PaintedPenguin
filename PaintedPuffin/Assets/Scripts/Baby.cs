using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement player;
    public GameManager gameManager;
    public SpriteRenderer sr;
    public int babyValue;
    public int offset;
    public int spacing;
    public int count;
    public float flightAngle;

    void Start()
    {
        count = 0;
        sr.flipX = false;
        animator.SetInteger("Baby", babyValue);
        player = FindObjectOfType<PlayerMovement>();
        flightAngle = Random.Range(0.6f, -0.6f);
        FindObjectOfType<AudioManager>().Play("peep");
    }
    
    void Update()
    {
        if (player.position == "starting")
        {
            sr.flipX = false;
        }

        if (gameManager.paused == false && player.playerPositions.Count > (offset + (spacing * babyValue)))
        {
            if (player.dead == false)
            {
                transform.position = player.playerPositions[offset + (spacing * babyValue)] - new Vector2(0.44f - (0.1f * babyValue), 0.07f);

                if (player.playerPositions2[offset + (spacing * babyValue)] == "walking")
                {
                    animator.SetBool("Jumping", false);
                    animator.SetBool("Swimming", false);
                    animator.SetBool("Dead", false);
                }
                else if (player.playerPositions2[offset + (spacing * babyValue)] == "jumping")
                {
                    animator.SetBool("Jumping", true);
                    animator.SetBool("Swimming", false);
                    animator.SetBool("Dead", false);
                }
                else if (player.playerPositions2[offset + (spacing * babyValue)] == "diving")
                {
                    animator.SetBool("Swimming", true);
                    animator.SetBool("Jumping", false);
                    animator.SetBool("Dead", false);
                }
            }
            else
            {
                transform.position += new Vector3(flightAngle * Time.deltaTime, 0.6f * Time.deltaTime, 0);
                if (flightAngle < 0)
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
                }
                animator.SetBool("Jumping", true);
                animator.SetBool("Swimming", false);
                animator.SetBool("Dead", false);

            }
        }
    }
}

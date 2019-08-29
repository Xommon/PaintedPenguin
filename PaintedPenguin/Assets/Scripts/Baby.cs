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
    }
    
    void Update()
    {
        if (gameManager.paused == false)
        {
            transform.position = player.playerPositions[10 * babyValue] - new Vector2(0.28f - (0.06f * babyValue), 0.07f);
        }
    }
}

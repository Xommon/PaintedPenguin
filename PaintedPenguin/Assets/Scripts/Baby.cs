using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour
{
    public Animator animator;
    public PlayerMovement player;
    public int babyValue;
    public Vector2 previousPosition1;
    public Vector2 previousPosition2;
    public Vector2 previousPosition3;

    public void Follow()
    {
        previousPosition1 = new Vector2(player.rb.position.x - (babyValue * 0.06f), player.rb.position.y - 0.07f);
        Invoke("Follow", babyValue);
    }
    
    void Start()
    {
        if (gameObject.name == "Baby")
        {
            babyValue = 1;
            //animator.SetInteger("Baby", babyValue);
        }

        if (gameObject.name == "Baby2")
        {
            babyValue = 2;
            //animator.SetInteger("Baby", babyValue);
        }

        if (gameObject.name == "Baby3")
        {
            babyValue = 3;
            //animator.SetInteger("Baby", babyValue);
        }

        Follow();
    }
    
    void Update()
    {
        transform.position = previousPosition1;
    }
}

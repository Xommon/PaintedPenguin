using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        animator.SetBool("splash", false);
    }

    void Update()
    {
        this.transform.position -= new Vector3(0.0025f, 0, 0);

        if (this.transform.position.x <= -1.01)
        {
            this.transform.position = new Vector3(1.39f, -0.28f, 0);
        }
    }
}

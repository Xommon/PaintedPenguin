﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float speed;
    public PlayerMovement player;

    void Update()
    {
        //Blocks keep moving to the left
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}

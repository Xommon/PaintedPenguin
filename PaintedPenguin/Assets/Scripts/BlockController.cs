﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    //GROUND = 0.16
    //AIR = 0.87
    //WATER = -0.91

    public float maxTime = 1;
    private float timer = 0;
    public GameObject block;
    float place;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (timer > maxtime)
        //{
        //    gameobject newblock = instantiate(block);
        //    int roll = random.range(1, 4); // 1, 2 or 3
        //    if (roll == 1)
        //    {
        //        place = 0.16f;
        //    }
        //    if (roll == 2)
        //    {
        //        place = 0.87f;
        //    }
        //    if (roll == 3)
        //    {
        //        place = -0.91f;
        //    }
        //    newblock.transform.position = transform.position + new vector3(1, place, 0);
        //    destroy(newblock, 2);
        //    timer = 0;
        //}
        //timer += time.deltatime;
    }
}

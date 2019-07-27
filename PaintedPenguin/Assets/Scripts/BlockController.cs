using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    // Middle = -0.1
    // High = 0.7
    // Low = -0.9

    public float maxTime = 1;
    private float timer = 0;
    public GameObject block;
    public GameObject paint;
    float place;

    void Ground()
    {
        place = -0.1f;
    }

    void Air()
    {
        place = 0.7f;
    }

    void Water()
    {
        place = -0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            GameObject newblock = Instantiate(block);
            int roll = Random.Range(1, 4); // 1, 2 or 3
            if (roll == 1)
            {
                Ground();
            }
            if (roll == 2)
            {
                Air();
            }
            if (roll == 3)
            {
                Water();
            }
            newblock.transform.position = transform.position + new Vector3(1, place, 0);
            Destroy(newblock, 2);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}

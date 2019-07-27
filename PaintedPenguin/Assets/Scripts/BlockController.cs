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
    public GameManager gameManager;
    float place;
    float place2;
    bool pass;

    void SpawnBlock()
    {
        if (timer > maxTime)
        {
            // Create the two blocks
            GameObject newblock = Instantiate(block);
            GameObject newblock2 = Instantiate(block);
            bool pass = false;

            // Randow draw to figure out placement of first block
            int roll = Random.Range(1, 4); // 1, 2 or 3
            if (roll == 1)
            {
                // Ground
                place = -0.1f;
            }
            if (roll == 2)
            {
                // Air
                place = 0.7f;
            }
            if (roll == 3)
            {
                // Water
                place = -0.9f;
            }

            // Place second block randomly where ever the first block is not
            int roll2 = Random.Range(1, 4); // 1, 2 or 3
            // If the first block is on the ground
            if (roll == 1)
            {
                if (roll2 == 1)
                {
                    // Air
                    place2 = 0.7f;
                }
                if (roll2 == 2)
                {
                    // Water
                    place2 = -0.9f;
                }
                if (roll2 == 3)
                {
                    // Out of frame
                    place2 = 2f;
                }
            }

            // If the first block is in the air
            if (roll == 2)
            {
                if (roll2 == 1)
                {
                    // Ground
                    place2 = -0.1f;
                }
                if (roll2 == 2)
                {
                    // Water
                    place2 = -0.9f;
                }
                if (roll2 == 3)
                {
                    // Out of frame
                    place2 = 2f;
                }
            }

            // If the first block is in the water
            if (roll == 3)
            {
                if (roll2 == 1)
                {
                    // Ground
                    place2 = -0.1f;
                }
                if (roll2 == 2)
                {
                    // Air
                    place2 = 0.7f;
                }
                if (roll2 == 3)
                {
                    // Out of frame
                    place2 = 2f;
                }
            }

            // Position the blocks
            newblock.transform.position = transform.position + new Vector3(1, place, 0);
            newblock2.transform.position = transform.position + new Vector3(1, place2, 0);

            // If the block passes by the player without being hit, then the player gets a point
            gameManager.score += 1;

            // Destroy the blocks once the timer runs out
            Destroy(newblock, 2);
            Destroy(newblock2, 2);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnBlock();
    }
}

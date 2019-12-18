using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject block;
    public PlayerMovement player;
    public GameObject fist;
    public float facing;
    public int colour;
    public int colour2;
    public SpriteRenderer sr;
    public SpriteRenderer sr2;
    public SpriteRenderer lidsr;
    public bool punch;
    public bool hit = false;
    public float moving;
    public float moveMax;
    public float moveMin;
    public int wave;
    public List<int> colours = new List<int>();
    public GameObject rainbow;
    public GameObject timesTwo;
    public GameObject timesThree;
    public GameObject baby;
    public GameObject magnet;
    public bool generated;
    public bool contentsActive;

    // Content parts
    public bool ejected;
    public GameObject rainbowContents;
    public GameObject timesTwoContents;
    public GameObject timesThreeContents;
    public GameObject babyContents;
    public GameObject magnetContents;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        facing = 0.1f;

        colours.Add(1);
        colours.Add(2);
        colours.Add(3);
        colours.Add(4);
        colours.Add(5);
        colours.Add(6);

        contentsActive = true;
        ejected = false;

        // Randomly choose block's colour
        int roll = Random.Range(1, 7); // Between 1 and 6
        if (roll == 1)
        {
            // Red
            colour = 1;
            colours.Remove(1);
            sr.color = gameManager.RedC;
        }
        if (roll == 2)
        {
            // Orange
            colour = 2;
            colours.Remove(2);
            sr.color = gameManager.OrangeC;
        }
        if (roll == 3)
        {
            // Yellow
            colour = 3;
            colours.Remove(3);
            sr.color = gameManager.YellowC;
        }
        if (roll == 4)
        {
            // Green
            colour = 4;
            colours.Remove(4);
            sr.color = gameManager.GreenC;
        }
        if (roll == 5)
        {
            // Blue
            colour = 5;
            colours.Remove(5);
            sr.color = gameManager.BlueC;
        }
        if (roll == 6)
        {
            // Purple
            colour = 6;
            colours.Remove(6);
            sr.color = gameManager.PurpleC;
        }

        if (colour == 1)
        {
            sr.color = gameManager.RedC;
        }
        else if (colour == 2)
        {
            sr.color = gameManager.OrangeC;
        }
        else if (colour == 3)
        {
            sr.color = gameManager.YellowC;
        }
        else if (colour == 4)
        {
            sr.color = gameManager.GreenC;
        }
        else if (colour == 5)
        {
            sr.color = gameManager.BlueC;
        }
        else if (colour == 6)
        {
            sr.color = gameManager.PurpleC;
        }

        if (gameObject.name == "BlockWithPaint(Clone)")
        {
            int roll2 = Random.Range(0, 5);
            colour2 = colours[roll2];

            if (colour2 == 1)
            {
                sr2.color = gameManager.RedC;
            }
            if (colour2 == 2)
            {
                sr2.color = gameManager.OrangeC;
            }
            if (colour2 == 3)
            {
                sr2.color = gameManager.YellowC;
            }
            if (colour2 == 4)
            {
                sr2.color = gameManager.GreenC;
            }
            if (colour2 == 5)
            {
                sr2.color = gameManager.BlueC;
            }
            if (colour2 == 6)
            {
                sr2.color = gameManager.PurpleC;
            }
        }
    }

    void Start()
    {
        // Determine which way to punch
        if (gameObject.name == "BlockWithFist" || gameObject.name == "BlockWithFist(Clone)")
        {
            punch = false;

            if (transform.position.y == 0.7f)
            {
                facing = 180;
            }
            else if (transform.position.y == -0.9f)
            {
                facing = 0;
            }
            else
            {
                if (gameManager.PercentChance(50))
                {
                    facing = 0;
                }
                else
                {
                    facing = 180;
                }
            }
        }
    }

    void Update()
    {
        if (colour == 1)
        {
            sr.color = gameManager.RedC;
        }
        else if (colour == 2)
        {
            sr.color = gameManager.OrangeC;
        }
        else if (colour == 3)
        {
            sr.color = gameManager.YellowC;
        }
        else if (colour == 4)
        {
            sr.color = gameManager.GreenC;
        }
        else if (colour == 5)
        {
            sr.color = gameManager.BlueC;
        }
        else if (colour == 6)
        {
            sr.color = gameManager.PurpleC;
        }

        transform.rotation = Quaternion.identity;

        // Blocks keep moving to the left
        transform.position += Vector3.left * 0.75f * Time.deltaTime;

        // Blocks move up and down
        transform.position += Vector3.up * moving * 1.0f * Time.deltaTime;

        // Change facing direction
        if ((gameObject.name == "BlockWithFist" || gameObject.name == "BlockWithFist(Clone)"))
        {
            transform.rotation = new Quaternion(0, 0, facing, 0);
            lidsr.color = sr.color;
        }

        // Destroy if out of scene
        if (transform.position.x < -0.9)
        {
            GameObject.Destroy(gameObject);
        }

        if (moveMax != 0 && moveMin != 0)
        {
            if (gameObject.transform.position.y > moveMax)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, moveMax, 0);
                moving *= -1;
            }

            if (gameObject.transform.position.y < moveMin)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, moveMin, 0);
                moving *= -1;
            }
        }

        // Activate fist
        if ((gameObject.name == "BlockWithFist" || gameObject.name == "BlockWithFist(Clone)") && punch == false && fist != null)
        {
            if (transform.position.x < 0.08f)
            {
                fist = Instantiate(fist, new Vector3(transform.position.x, transform.position.y + 0.4f), transform.rotation, gameObject.transform);
                fist.GetComponent<Fist>().blockWithFist = gameObject;
                punch = true;
                FindObjectOfType<AudioManager>().Play("fistwhoosh");
            }
        }

        // Eject contents if magnet is enabled
        if (FindObjectOfType<PlayerMovement>().magnet == true && transform.position.x < 0.5)
        {
            contentsActive = false;

            if (ejected == false)
            {
                if (name == "BlockWithRainbow" || name == "BlockWithRainbow(Clone)")
                {
                    Instantiate(rainbow, transform.position, Quaternion.identity);
                    contentsActive = false;
                    rainbowContents.SetActive(false);
                    ejected = true;
                }
                else if (name == "BlockWithX2" || name == "BlockWithX2(Clone)")
                {
                    Instantiate(timesTwo, transform.position, Quaternion.identity);
                    contentsActive = false;
                    timesTwoContents.SetActive(false);
                    ejected = true;
                }
                else if (name == "BlockWithX3" || name == "BlockWithX3(Clone)")
                {
                    Instantiate(timesThree, transform.position, Quaternion.identity);
                    contentsActive = false;
                    timesThreeContents.SetActive(false);
                    ejected = true;
                }
                else if (name == "BlockWithBaby" || name == "BlockWithBaby(Clone)")
                {
                    Instantiate(baby, transform.position, Quaternion.identity);
                    contentsActive = false;
                    babyContents.SetActive(false);
                    ejected = true;
                }
                else if (name == "BlockWithMagnet" || name == "BlockWithMagnet(Clone)")
                {
                    Instantiate(magnet, transform.position, Quaternion.identity);
                    contentsActive = false;
                    magnetContents.SetActive(false);
                    ejected = true;
                }
            }
        }
    }
}

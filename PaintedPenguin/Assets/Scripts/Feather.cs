using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feather : MonoBehaviour
{
    public int count;
    public bool burst;
    public float time;
    [System.NonSerialized]
    public float speed;
    [System.NonSerialized]
    public float burstSpeed;
    public SpriteRenderer sr;
    public PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        count = Mathf.RoundToInt(time / 2);
        burst = true;
        speed  = Random.Range(0.5f, 1.1f);
        time *= speed;

        burstSpeed = Random.Range(0.5f, 1.1f);
        sr.color = player.sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        transform.position += Vector3.down * (speed * 0.1f) * Time.deltaTime;

        if (count <= time)
        {
            transform.position += Vector3.right * (speed * 0.1f) * Time.deltaTime;
            transform.Rotate(0, 0, (speed * 50f * Time.deltaTime));
        }
        else if (count <= time * 2)
        {
            transform.position += Vector3.left * (speed * 0.1f) * Time.deltaTime;
            transform.Rotate(0, 0, (speed * -50f * Time.deltaTime));
        }
        else
        {
            count = 1;
        }

        if (burst == true)
        {
            if (transform.name == "Feather") transform.position += new Vector3(0, 2f * burstSpeed, 0) * Time.deltaTime;
            if (transform.name == "Feather (1)") transform.position += new Vector3(2f * burstSpeed, 0, 0) * Time.deltaTime;
            if (transform.name == "Feather (2)") transform.position += new Vector3(-2f * burstSpeed, 0, 0) * Time.deltaTime;
            if (transform.name == "Feather (3)") transform.position += new Vector3(1.5f * burstSpeed, burstSpeed, 0) * Time.deltaTime;
            if (transform.name == "Feather (4)") transform.position += new Vector3(-1.5f * burstSpeed, burstSpeed, 0) * Time.deltaTime;
        }

        if (burstSpeed > 0)
        {
            burstSpeed -= 0.035f;
        } else
        {
            burstSpeed = 0;
        }
    }
}

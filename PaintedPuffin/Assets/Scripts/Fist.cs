using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fist : MonoBehaviour
{
    public GameObject blockWithFist;
    public BoxCollider2D boxCollider;
    public GameManager gameManager;
    public PlayerMovement player;
    public GameObject paintSplatter;
    public Color paintSplatterColour;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        player = FindObjectOfType<PlayerMovement>();
        paintSplatterColour = new Color(0, 0, 0, 0);
        boxCollider.enabled = false;

        if (blockWithFist.GetComponent<Block>().facing == 0)
        {
            transform.position = blockWithFist.transform.position + new Vector3(0, 0.4f, 0);
        }
        else if (blockWithFist.GetComponent<Block>().facing == 180)
        {
            transform.position = blockWithFist.transform.position + new Vector3(0, -0.4f, 0);
        }

        transform.rotation = new Quaternion(0, 0, blockWithFist.GetComponent<Block>().facing, 0);

        Invoke("EnablePaintSplatter", 0.17f);
    }

    public void EnablePaintSplatter()
    {
        boxCollider.enabled = true;
        paintSplatter.GetComponent<SpriteRenderer>().color = paintSplatterColour;
        paintSplatter.SetActive(true);
    }

    void Update()
    {
        if (blockWithFist.GetComponent<Block>().facing == 0)
        {
            transform.position = blockWithFist.transform.position + new Vector3(0, 0.4f, 0);
        }
        else if (blockWithFist.GetComponent<Block>().facing == 180)
        {
            transform.position = blockWithFist.transform.position + new Vector3(0, -0.4f, 0);
        }

        if (FindObjectOfType<PlayerMovement>().dead == true)
        {
            boxCollider.enabled = false;
        }

        paintSplatter.GetComponent<SpriteRenderer>().color = paintSplatterColour;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name != "Player")
        {
            if (collision.transform.tag == "Block")
            {
                ParticleSystem ps = Instantiate(player.blockBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ParticleSystem ps2 = Instantiate(player.dustBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ps.startColor = collision.gameObject.GetComponent<Block>().sr.color;
                Destroy(ps.gameObject, ps.startLifetime);
                Destroy(ps2.gameObject, ps2.startLifetime);
                FindObjectOfType<AudioManager>().Play("blockdestroy");
            }
            else if (collision.transform.tag == "Paint")
            {
                ParticleSystem ps3 = Instantiate(player.paintBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ps3.startColor = collision.gameObject.GetComponent<Paint>().sr.color;
                paintSplatterColour = collision.gameObject.GetComponent<Paint>().sr.color;
                Destroy(ps3.gameObject, ps3.startLifetime);
                FindObjectOfType<AudioManager>().Play("bubble" + Random.Range(1,4));
            }
            else if (collision.transform.tag == "Rainbow")
            {
                ParticleSystem ps3 = Instantiate(player.paintBurst, collision.transform.position, Quaternion.identity) as ParticleSystem;
                ps3.startColor = collision.gameObject.GetComponent<Rainbow>().sr.color;
                paintSplatterColour = collision.gameObject.GetComponent<Rainbow>().sr.color;
                Destroy(ps3.gameObject, ps3.startLifetime);
                FindObjectOfType<AudioManager>().Play("bubble" + Random.Range(1, 4));
            }

            Destroy(collision.gameObject);
        }
    }
}

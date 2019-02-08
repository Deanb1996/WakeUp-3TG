using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepleController : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    float timer;
    bool jumped = true;
    public float smartness;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if (jumped == false)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            jumped = true;
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.transform.tag == "jumpPoint")
    //    {
    //        rb.velocity = Vector2.up * jumpVelocity;
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.tag == "jumpPoint")
        {
            timer = Random.value / smartness;
            jumped = false;
        }
    }



}

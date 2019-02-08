using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    public GameObject jumpPoint;
    bool jumped = true;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && jumped == false)
        {
            Vector3 jumpPointPos = rb.transform.position;
            Instantiate(jumpPoint, jumpPointPos, Quaternion.identity);
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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.tag == "deathZone")
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.tag == "building")
        {
            jumped = false;
        }

        if (collision.gameObject.transform.tag == "bossTrigger")
        {
            // fade to black, unload level 1, load boss level and then fade in.
            float fadeSpeed = GameObject.Find("BossTrigger").GetComponent<FadeOut>().BeginFade();
            StartCoroutine(test(fadeSpeed));
        }
    }

    IEnumerator test(float fadeSpeed)
    {
        yield return new WaitForSeconds(fadeSpeed);
        SceneManager.LoadScene("BossTest");
    }
}

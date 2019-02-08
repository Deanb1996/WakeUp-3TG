using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBossTest : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    public float velocity;
    bool jumped = false;

    float health = 3;
    public Text healthText;

    private bool boundaryCollision;
    private bool boundaryLeftCollision;

    private float runTimer;
    private bool autoRun = true;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        runTimer++;

        if (runTimer > 60)
        {
            autoRun = false;
        }

        if (autoRun)
        {
            this.transform.position = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }


        healthText.text = health.ToString();

        if (Input.GetKey(KeyCode.Space) && jumped == false)
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

        if (Input.GetKey(KeyCode.A) && boundaryLeftCollision == false)
        {
            rb.transform.position -= Vector3.right * velocity;
            rb.transform.rotation = new Quaternion(0, -180, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) && boundaryCollision == false)
        {
            rb.transform.position += Vector3.right * velocity;
            rb.transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "building")
        {
            jumped = false;
        }
        if (collision.gameObject.tag == "boss")
        {
            health = health - 1;
        }
        if (collision.gameObject.tag == "boundary")
        {
            boundaryCollision = true;
        }
        if (collision.gameObject.tag == "boundaryLeft")
        {
            boundaryLeftCollision = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boundary")
        {
            boundaryCollision = false;
        }
        if (collision.gameObject.tag == "boundaryLeft")
        {
            boundaryLeftCollision = false;
        }
    }


    // TODO: PLAYER HEALTH
}

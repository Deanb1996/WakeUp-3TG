using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{

    Rigidbody2D rb;
    Rigidbody2D rb2;
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;
    float timer;
    bool jumped = true;
    public float frequency;
    public float frequency2;
    public float amplitude;
    public float amplitude2;

    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        rb.transform.position = new Vector3(Mathf.Sin(frequency * timer) * amplitude, Mathf.Sin(frequency2 * timer) * amplitude2, transform.position.z);
    }
}

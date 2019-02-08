using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : MonoBehaviour
{
    Rigidbody2D rb;
    public float frequency;
    float timer;
    public float amplitude;
    public float offsetY;
    public int range;
    int freezeTime = 1;
    float freezeArmTimer = 1.1f;
    bool frozenArm = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (frozenArm)
        {
            freezeArmTimer += Time.deltaTime;
        }

            if ((Random.Range(0, range) == 0) && !frozenArm)
            {
                //rb.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                frozenArm = true;
                freezeArmTimer = 0;
            }
            else if (freezeArmTimer > freezeTime)
            {
                timer += Time.deltaTime;
                rb.transform.position = new Vector3(transform.position.x, Mathf.Sin(-frequency * timer) * amplitude - offsetY, transform.position.z);
                frozenArm = false;
            }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    Rigidbody2D rb;
    public float velocity;
    private float timer;
    public float lifeTime;
    public float depth;
    Vector3 mousePosition;
    Vector3 direction;

    // Use this for initialization
    void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();


        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, depth));
        mousePosition.z = 0;
        direction = Vector3.Normalize(mousePosition - rb.transform.position);
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.transform.position += direction * velocity * Time.deltaTime;

        timer += Time.deltaTime;

        if(timer >= lifeTime)
        {
            timer = 0;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}

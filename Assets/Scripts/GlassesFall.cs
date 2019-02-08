using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesFall : MonoBehaviour {

    Rigidbody2D rb;
    public float velocity;
    public float stoppingHeight;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.transform.position.y > stoppingHeight)
        {
            Vector3 position = new Vector3(rb.transform.position.x, rb.transform.position.y - velocity, rb.transform.position.z);
            rb.transform.position = position;
        }
	}
}

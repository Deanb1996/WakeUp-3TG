using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour {

    Rigidbody2D rb;
    public float velocity;

	// Use this for initialization
	void Awake ()
    {
        rb = GetComponent<Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update ()
    {
        rb.transform.position -= Vector3.right * velocity;
	}
}

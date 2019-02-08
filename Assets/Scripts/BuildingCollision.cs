using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollision : MonoBehaviour {

    public Vector2 upCollision = Vector2.up;
	// Use this for initialization
	void Start () {
        GetComponent<Collider2D>().attachedRigidbody.AddForce(upCollision);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

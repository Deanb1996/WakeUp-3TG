using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject bullet;
    private GameObject bulletInstance;
    public float fireRate;
    private float timer;
    private Transform bulletSpawn;

	// Use this for initialization
	void Awake ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        bulletSpawn = transform.Find("bulletSpawn");
        timer += Time.deltaTime;
		if(Input.GetKey(KeyCode.Mouse0) && timer >= fireRate)
        {
            bulletInstance = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            timer = 0;
        }
	}
}

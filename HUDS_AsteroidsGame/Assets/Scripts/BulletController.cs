using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	//variable definitions
	public float bulletforce;
	public float bulletTime = 1.0f;

	// Use this for initialization
	void Start () {
		// Set the bullet to destroy itself after an amount of time (seconds)
		Destroy (gameObject, bulletTime);

		// Push the bullet in the direction it is facing
		GetComponent<Rigidbody2D>().AddForce(transform.up * bulletforce);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

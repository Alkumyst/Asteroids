using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour {

	//variable definitions
	public AudioClip destroy;
	public GameObject smallAsteroid;

	public float asteroidforce1 = -50.0f;
	public float asteroidforce2 = 150.0f;
	public float volume2 = 1;


	private GameController gameController;

	// Use this for initialization
	public void Start () {

		// Get a reference to the game controller object and the script
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		gameController = gameControllerObject.GetComponent <GameController>();

		// Push the asteroid in the direction it is facing
		GetComponent<Rigidbody2D>().AddForce(transform.up * Random.Range(asteroidforce1, asteroidforce2));

		// Give a random angular velocity/rotation
		GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-0.0f, 90.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Equals)) { //increases volume
			volume2 = volume2 + 0.1f;
		}
		if(Input.GetKeyDown(KeyCode.Minus)) { //decreases volume
			volume2 = volume2 - 0.1f;
		}
	}

	void OnCollisionEnter2D(Collision2D c) {

		if (c.gameObject.tag.Equals("Bullet")) {

			// Destroy the bullet
			Destroy (c.gameObject);

			// If large spawn new small
			if (tag.Equals ("Large Asteroid")) {
				// Spawn small asteroid 1
				Instantiate (smallAsteroid, new Vector3 (transform.position.x - .5f, transform.position.y - .5f, 0), Quaternion.Euler (0, 0, 90));
				// Spawn small asteroid 2
				Instantiate (smallAsteroid, new Vector3 (transform.position.x + .5f, transform.position.y + .0f, 0), Quaternion.Euler (0, 0, 0));
				// Spawn small asteroid 3
				Instantiate (smallAsteroid, new Vector3 (transform.position.x + .5f, transform.position.y - .5f, 0), Quaternion.Euler (0, 0, 270));

				gameController.SplitAsteroid (); // +2 to total

			} else {
				// Just a small asteroid destroyed
				gameController.DecrementAsteroids();
			}

			// Play destroy sound
			AudioSource.PlayClipAtPoint(destroy, Camera.main.transform.position, volume2);

			// Add to score
			gameController.IncrementScore();

			// Destroy the current asteroid
			Destroy (gameObject);

		}

	}

}

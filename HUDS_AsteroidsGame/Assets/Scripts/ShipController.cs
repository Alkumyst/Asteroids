using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	//variable definitions
	public float rotationSpeed = 200.0f;
	public float thrustForce = 3f;
	public float volume = 1f;

	public AudioClip crash;
	public AudioClip shoot;

	public GameObject bullet;

	private GameController gameController;

	// Use this for initialization
	void Start () {

		// Get a reference to the game controller object and the script
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

		gameController = gameControllerObject.GetComponent <GameController>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

		// Rotate the ship if necessary
		transform.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);

		// Thrust the ship if necessary
		GetComponent<Rigidbody2D>().AddForce(transform.up * thrustForce * Input.GetAxis("Vertical"));

		// Has a bullet been fired
		if (Input.GetKeyDown ("space"))
			ShootBullet ();

	}

	void OnTriggerEnter2D(Collider2D c){

		// Anything except a bullet is an asteroid
		if (c.gameObject.tag != "Bullet") {

			AudioSource.PlayClipAtPoint (crash, Camera.main.transform.position, volume);

			// Move the ship to the centre of the screen
			transform.position = new Vector3 (0, 0, 0); 

			// Remove all velocity from the ship
			GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 0, 0);

			gameController.DecrementLives ();

			//need to press space to restart
		}
	}

	void ShootBullet(){

		// Spawn a bullet
		Instantiate(bullet, new Vector3(transform.position.x,transform.position.y, 0), transform.rotation);

		// Play a shoot sound
		AudioSource.PlayClipAtPoint (shoot, Camera.main.transform.position, volume);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Equals)) { //volume up with +
			volume = volume + 0.1f;
		}
		if(Input.GetKeyDown(KeyCode.Minus)) { //volume down with -
			volume = volume - 0.1f;		
		}
	}

}

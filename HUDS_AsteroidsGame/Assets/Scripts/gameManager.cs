using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour {

	//variable definitions
	public static gameManager instance;

	public int score;
	public int numTargets;

	public GameObject game;
	public GameObject StartScreen;
	public GameObject LossScreen;
	public GameObject WinScreen;

	public GameObject targetPrefab;


	void Awake () {
		//if there is no instance
		if (instance == null) {
			//this GameManager is the simpleton
			instance = this;
			//Make sure this isnt deleted if i load another level
			DontDestroyOnLoad(gameObject);
		} else {
			//otherwise, destroy this gameobject (there can only be one.)
			Destroy (gameObject);
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}

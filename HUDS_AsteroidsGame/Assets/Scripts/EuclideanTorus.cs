using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EuclideanTorus : MonoBehaviour {

	//variable definitions
	public float minX = -9;
	public float maxX = 9;
	public float minY = -5;
	public float maxY = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Teleport the game object
		if(transform.position.x > maxX){
			transform.position = new Vector3 (minX, transform.position.y, 0);
		}
		else if(transform.position.x < minX){
			transform.position = new Vector3(maxX, transform.position.y, 0);
		}

		else if(transform.position.y > maxY){
			transform.position = new Vector3(transform.position.x, minY, 0);
		}

		else if(transform.position.y < minY){
			transform.position = new Vector3(transform.position.x, maxY, 0);
		}
	}
}

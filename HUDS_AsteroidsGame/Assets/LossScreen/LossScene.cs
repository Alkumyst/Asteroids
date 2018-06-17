using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUpAsButton () {
		gameManager.instance.LossScreen.SetActive (false); //sets loss screen to off
		gameManager.instance.StartScreen.SetActive (true); //sets startscreen to on

	}
}

﻿using UnityEngine;
using System.Collections;


public class RockBoatCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Boat")
			Debug.Log ("Collided!");
	}
}
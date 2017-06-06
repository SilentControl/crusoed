using UnityEngine;
using System.Collections;

public class IntroCameraMove : MonoBehaviour {
	float increment = -0.02f;
	Vector3 newPosition;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		newPosition = transform.position;
		newPosition.y += increment; 
		if (newPosition.y < -110.0f) {
			newPosition.y = 7.3f;
		}
		transform.position = newPosition;
	}
}

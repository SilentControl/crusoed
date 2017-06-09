using UnityEngine;
using System.Collections;

public class GraveGatePuzzle : MonoBehaviour {
	// Use this for initialization
	GameObject head;
	void Start () {
		head = transform.GetChild (0).gameObject;
		head.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void complete()
	{
		head.SetActive (true);
		for (int i = 2; i < transform.childCount; i++)
		{
			transform.GetChild (i).gameObject.SetActive (false);	
		}
	}
}

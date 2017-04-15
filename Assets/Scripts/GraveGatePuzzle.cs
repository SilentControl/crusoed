using UnityEngine;
using System.Collections;

public class GraveGatePuzzle : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void complete()
	{
		for (int i = 1; i < transform.childCount; i++)
		{
			transform.GetChild (i).gameObject.SetActive (false);	
		}
	}
}

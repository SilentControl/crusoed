using UnityEngine;
using System.Collections;

public class EndingLoadMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void continueMenu()
	{
		Application.LoadLevel (0);
	}
}

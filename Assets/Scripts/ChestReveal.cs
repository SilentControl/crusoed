using UnityEngine;
using System.Collections;

public class ChestReveal : MonoBehaviour {

	// Use this for initialization
	GameObject campFire;
	GameObject chest;
	GameObject warper;
	GameObject signPost;

	bool isFireLit;
	void Start () {
		campFire = transform.GetChild (0).gameObject;
		chest = transform.GetChild (1).gameObject;
		warper = transform.GetChild (2).gameObject;
		signPost = transform.GetChild (3).gameObject;

		chest.SetActive (false);
		warper.SetActive (false);
		signPost.SetActive (false);

		isFireLit = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isFireLit == false)
		{
			if (campFire.GetComponent<SetFire> ().isOnFire == true)
			{
				chest.SetActive (true);
				warper.SetActive (true);
				signPost.SetActive (true);
				isFireLit = true;
			}
		}
	}
}

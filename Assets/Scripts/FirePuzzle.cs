using UnityEngine;
using System.Collections;

public class FirePuzzle : MonoBehaviour {
	bool gotKey;
	GameObject springKey;
	// Use this for initialization
	void Start () {
		gotKey = false;
		springKey = transform.GetChild(0).gameObject;
		springKey.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		bool allFiresLit = true;
		for (int i = 1; i < transform.childCount; i++)
		{
			GameObject child = transform.GetChild (i).gameObject;
			if (child.GetComponent<SetFire> ().isOnFire == false)
			{
				allFiresLit = false;
				break;
			}
		}

		if (allFiresLit == true && gotKey == false)
		{
			springKey.SetActive (true);
			gotKey = true;
		}
			
	}
}

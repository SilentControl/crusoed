using UnityEngine;
using System.Collections;

public class FishPuzzle : MonoBehaviour {
	bool gotPrize;
	GameObject steelCup;
	GameObject steelBar;
	// Use this for initialization
	void Start () {
		gotPrize = false;
		steelCup = transform.GetChild(0).GetChild(0).gameObject;
		steelBar = transform.GetChild(0).GetChild(1).gameObject;
		steelBar.SetActive(false);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate ()
	{
		bool allFishInserted = true;
		for (int i = 1; i < transform.childCount; i++)
		{
			GameObject child = transform.GetChild (i).gameObject;
			if (child.GetComponent<AddFishPuzzle> ().fishInserted == false)
			{
				allFishInserted = false;
				break;
			}
		}

		if (allFishInserted == true && gotPrize == false)
		{
			steelCup.SetActive (false);
			steelBar.SetActive (true);
			gotPrize = true;
		}

	}
}

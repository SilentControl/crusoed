using UnityEngine;
using System.Collections;

public class FireDemonPuzzle : MonoBehaviour {
	public GameObject player;
	InventoryNew inventory;
	bool solved;
	GameObject fireDemon;
	// Use this for initialization
	void Start () {
		inventory = player.GetComponent<InventoryNew> ();
		solved = false;

		// set FireDemon inactive
		fireDemon = transform.GetChild (5).transform.gameObject;
		fireDemon.SetActive (false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		bool requirements = true;

		// check if the crystals are inserted
		for (int i = 0; i < 3; i++)
		{
			if (transform.GetChild (i).GetComponent<CrystalAdd> ().crystalAdded == false)
			{
				requirements = false;
				break;
			}
		}

		// check if the fire is lit
		if (transform.GetChild (3).GetComponent<SetFire> ().isOnFire == false)
		{
			requirements = false;
		}

		// check if the player has got the scroll
		if (inventory.itemExists ((int)itemEnum.SCROLL) == -1)
		{
			requirements = false;
		}

		if (requirements == true)
		{
			// enable the fire demon
			fireDemon.SetActive (true);

			// open the frozen gate
			transform.GetChild(4).transform.gameObject.SetActive(false);
		}
	}
}

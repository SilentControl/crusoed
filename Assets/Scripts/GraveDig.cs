using UnityEngine;
using System.Collections;

public class GraveDig : MonoBehaviour {
	public itemEnum reward;

	bool dug;
	bool nearGrave;
	Collider2D player;
	bool noreward;
	// Use this for initialization
	void Start () {
		dug = false;
		nearGrave = false;
		noreward = true;

		// check if the key is the reward
		if (reward == itemEnum.AUTUMNKEY && transform.childCount > 1)
		{
			transform.GetChild (1).gameObject.SetActive (false);
		}

		if (reward == itemEnum.AUTUMNKEY || reward == itemEnum.IRON || reward == itemEnum.STEEL) 
		{
			noreward = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearGrave == true && player != null && dug == false && noreward == false)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				int shovelPosition = inventory.itemExists((int)itemEnum.SHOVEL);

				if (shovelPosition != -1)
				{
					player.transform.GetChild (2).GetChild (10).GetComponent<AudioSource> ().Play ();
					if (reward != itemEnum.AUTUMNKEY)
					{
						inventory.addItem ((int)reward);
						dug = true;
					}

					else
					{
						// destroy the grave
						transform.GetChild (0).gameObject.SetActive (false);
						// spawn the key
						transform.GetChild (1).gameObject.SetActive (true);
						dug = true;
					}
				}
			}

			if (nearGrave == true && player != null && dug == true)
			{
				player.transform.GetChild (2).GetChild (10).GetComponent<AudioSource> ().Play ();
			}

			if (nearGrave == true && player != null && noreward == true)
			{
				player.transform.GetChild (2).GetChild (10).GetComponent<AudioSource> ().Play ();
			}
		}	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearGrave = true;
			player = other;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearGrave = false;
			player = null;
		}
	}
}

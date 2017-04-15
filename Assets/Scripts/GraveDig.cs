using UnityEngine;
using System.Collections;

public class GraveDig : MonoBehaviour {
	public itemEnum reward;

	bool dug;
	bool nearGrave;
	Collider2D player;
	// Use this for initialization
	void Start () {
		dug = false;
		nearGrave = false;

		// check if the key is the reward
		if (reward == itemEnum.AUTUMNKEY && transform.childCount > 1)
		{
			transform.GetChild (1).gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearGrave == true && player != null && dug == false)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				int shovelPosition = inventory.itemExists((int)itemEnum.SHOVEL);

				if (shovelPosition != -1)
				{
					if (reward != itemEnum.AUTUMNKEY)
					{
						inventory.addItem ((int)reward);
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

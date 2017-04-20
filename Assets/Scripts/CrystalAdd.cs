using UnityEngine;
using System.Collections;

public class CrystalAdd : MonoBehaviour {
	public bool nearCrystalSlot;
	public itemEnum crystalType;
	public bool crystalAdded;
	Collider2D player;
	// Use this for initialization
	void Start () {
		nearCrystalSlot = false;
		player = null;
		crystalAdded = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearCrystalSlot == true && player != null && crystalAdded == false)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				int crystalPosition = inventory.itemExists((int)crystalType);
				if (crystalPosition != -1)
				{
					inventory.removeItem(crystalPosition);
					crystalAdded = true;
				}
			}
		}	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearCrystalSlot = true;
			player = other;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearCrystalSlot = false;
			player = null;
		}
	}
}

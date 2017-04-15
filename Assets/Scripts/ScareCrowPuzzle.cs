using UnityEngine;
using System.Collections;

public class ScareCrowPuzzle : MonoBehaviour {
	public bool nearScareCrow;
	Collider2D player;
	public bool headAttached;
	// Use this for initialization
	void Start () {
		nearScareCrow = false;
		player = null;
		headAttached = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearScareCrow == true && player != null && headAttached == false)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				int jackPosition = inventory.itemExists((int)itemEnum.JACKOLANTERN);
				if (jackPosition != -1)
				{
					inventory.removeItem(jackPosition);
					headAttached = true;
					SendMessageUpwards ("complete");
				}
			}
		}	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearScareCrow = true;
			player = other;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearScareCrow = false;
			player = null;
		}
	}
}

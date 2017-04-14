using UnityEngine;
using System.Collections;

public class AnvilSmith : MonoBehaviour {
	public bool nearAnvil;
	Collider2D player;
	// Use this for initialization
	void Start () {
		nearAnvil = false;
		player = null;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearAnvil == true && player != null)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				int stickPosition = inventory.itemExists((int)itemEnum.STICK);
				int rockPosition = inventory.itemExists((int)itemEnum.STONE);
				int ironPosition = inventory.itemExists((int)itemEnum.IRON);
				int steelPosition = inventory.itemExists((int)itemEnum.STEEL);
				if (stickPosition != -1 && inventory.stacks[stickPosition].size >= 2 &&
					rockPosition != -1 && inventory.stacks[rockPosition].size >= 1 &&
					ironPosition != -1 && inventory.stacks[ironPosition].size >= 5 &&
					steelPosition != -1 && inventory.stacks[steelPosition].size >= 1)
				{
					for (int i = 1; i <= 2; i++)
						inventory.removeItem(stickPosition);
					
					inventory.removeItem(inventory.itemExists((int)itemEnum.STONE));

					for (int i = 1; i <= 5; i++)
						inventory.removeItem(inventory.itemExists((int)itemEnum.IRON));

					inventory.removeItem(inventory.itemExists((int)itemEnum.STEEL));

					inventory.addItem ((int)itemEnum.SWORD);
				}
			}
		}	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearAnvil = true;
			player = other;
			player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.nearAnvil);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearAnvil = false;
			player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.idle);
			player = null;
		}
	}
}

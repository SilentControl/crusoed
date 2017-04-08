using UnityEngine;
using System.Collections;

public class MineRock : MonoBehaviour {

	public bool nearRock;
	public Collider2D player;
	// Use this for initialization
	void Start()
	{
		nearRock = false;
		player = null;
	}
	
	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearRock == true && player != null)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				if (inventory.itemExists((int)itemEnum.PICKAXE) != -1)
				{
					player.gameObject.GetComponent<InventoryNew>().addItem((int)itemEnum.STONE);
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearRock = true;
			player = other;
			player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.nearRock);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearRock = false;
			player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.idle);
			player = null;
		}
	}
}

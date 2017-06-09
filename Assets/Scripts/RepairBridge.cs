using UnityEngine;
using System.Collections;

public class RepairBridge : MonoBehaviour {
	public bool nearBridge;
	public bool repaired;
	Collider2D player;
	GameObject brokenBridge;
	GameObject fixedBridge;
	// Use this for initialization
	void Start () {
		nearBridge = false;
		repaired = false;
		player = null;
		brokenBridge = transform.GetChild (0).gameObject;
		fixedBridge = transform.GetChild (1).gameObject;
		fixedBridge.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearBridge == true && player != null && repaired == false)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				int stickPosition = inventory.itemExists((int)itemEnum.STICK);
				int rockPosition = inventory.itemExists((int)itemEnum.STONE);
				int ironPosition = inventory.itemExists((int)itemEnum.IRON);
				int lianaPosition = inventory.itemExists((int)itemEnum.LIANA);

				if (stickPosition != -1 && inventory.stacks[stickPosition].size >= 5 &&
					rockPosition != -1 && inventory.stacks[rockPosition].size >= 5 &&
					lianaPosition != -1 && inventory.stacks[lianaPosition].size >= 5 &&
					ironPosition != -1 && inventory.stacks[ironPosition].size >= 1)
				{
					for (int i = 1; i <= 5; i++)
						inventory.removeItem(stickPosition);

					for (int i = 1; i <= 5; i++)
						inventory.removeItem(inventory.itemExists((int)itemEnum.STONE));

					for (int i = 1; i <= 5; i++)
						inventory.removeItem(inventory.itemExists((int)itemEnum.LIANA));

					inventory.removeItem(inventory.itemExists((int)itemEnum.IRON));

					repaired = true;
					brokenBridge.SetActive (false);
					fixedBridge.SetActive (true);
				}
			}
		}		
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearBridge = true;
			player = other;
			player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.nearBridge);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearBridge = false;
			player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.idle);
			player = null;
		}
	}
}

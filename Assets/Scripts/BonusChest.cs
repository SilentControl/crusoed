using UnityEngine;
using System.Collections;

public class BonusChest : MonoBehaviour {
	public bool nearChest;
	public bool isOpen;
	public Collider2D player;
	GameObject closedChest;
	GameObject openedChest;
	int ticks;

	itemEnum[] reward = {itemEnum.APPLE, itemEnum.IRON, itemEnum.STONE, itemEnum.RAWFISH, itemEnum.PUMPKIN};
	// Use this for initialization
	void Start () {
		nearChest = false;
		player = null;
		isOpen = false;
		closedChest = transform.GetChild (0).gameObject;
		openedChest = transform.GetChild (1).gameObject;
		openedChest.SetActive (false);	
	}
	
	void FixedUpdate () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearChest == true && player != null && isOpen == false)
			{
				// open the chest
				closedChest.SetActive (false);
				openedChest.SetActive (true);
				isOpen = true;

				// give reward to the player
				player.GetComponent<InventoryNew>().addItem((int)reward[Random.Range(0, reward.Length)]);
			}
		}

		if (isOpen == true)
		{
			ticks++;
			if (ticks >= 3000)
			{
				closedChest.SetActive (true);
				openedChest.SetActive (false);
				ticks = 0;
				isOpen = false;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearChest = true;
			player = other;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearChest = false;
			player = null;
		}
	}
}

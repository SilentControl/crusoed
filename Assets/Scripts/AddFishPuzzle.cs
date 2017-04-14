using UnityEngine;
using System.Collections;

public class AddFishPuzzle : MonoBehaviour {

	public GameObject ItemDatabase;
	public bool nearFishIdent;

	public bool fishInserted;
	Collider2D player;
	ItemCollection collection;
	// Use this for initialization
	void Start () {
		nearFishIdent = false;
		player = null;
		fishInserted = false;
		collection = ItemDatabase.GetComponent<ItemCollection> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearFishIdent == true && player != null)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				int cookedFish = inventory.itemExists ((int)itemEnum.COOKEDFISH);
				if (cookedFish != -1)
				{
					inventory.removeItem (cookedFish);
					fishInserted = true;
					gameObject.GetComponent<SpriteRenderer> ().sprite = collection.itemDictionary [(int)itemEnum.COOKEDFISH].icon;
				}
			}
		}	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearFishIdent = true;
			player = other;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearFishIdent = false;
			player = null;
		}
	}
}

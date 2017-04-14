using UnityEngine;
using System.Collections;

public class ExcalliburEvent : MonoBehaviour {
	public bool nearBoulder;
	Collider2D player;

	bool gotKey;
	GameObject summerKey;
	GameObject boulder;
	// Use this for initialization
	void Start () {
		gotKey = false;
		summerKey = transform.GetChild(0).gameObject;
		boulder = transform.GetChild(1).gameObject;
		summerKey.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearBoulder == true && player != null)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				if (inventory.itemExists((int)itemEnum.SWORD) != -1)
				{
					if (gotKey == false)
					{
						boulder.SetActive (false);
						summerKey.SetActive (true);
					}
				}
			}
		}	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearBoulder = true;
			player = other;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearBoulder = false;
			player = null;
		}
	}
}

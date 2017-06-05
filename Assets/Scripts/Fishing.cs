using UnityEngine;
using System.Collections;

public class Fishing : MonoBehaviour {

	public int ironSupply;
	public bool nearSpot;
	public Collider2D player;
	bool timeout;
	// Use this for initialization
	void Start()
	{
		nearSpot = false;
		player = null;
		timeout = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearSpot == true && player != null && timeout == false)
			{
				InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
				if (inventory.itemExists((int)itemEnum.ROD) != -1)
				{
					if (ironSupply > 0) {
						int rand = Random.Range (0, 10);
						if (rand % 2 == 0)
							player.gameObject.GetComponent<InventoryNew> ().addItem ((int)itemEnum.RAWFISH);
						else {
							player.gameObject.GetComponent<InventoryNew> ().addItem ((int)itemEnum.IRON);
							ironSupply--;
						}
					} else {
						player.gameObject.GetComponent<InventoryNew> ().addItem ((int)itemEnum.RAWFISH);
					}

					timeout = true;
					player.transform.GetChild (2).GetChild (5).GetComponent<AudioSource> ().Play ();
					StartCoroutine (DelayCollect ());
				}
			}
		}
	}



	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearSpot = true;
			player = other;
			player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.nearFishSpot);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearSpot = false;
			player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.idle);
			player = null;
		}
	}

	IEnumerator DelayCollect()
	{
		yield return new WaitForSecondsRealtime (1.5f);
		timeout = false;
	}
}

using UnityEngine;
using System.Collections;

public class RequireItem : MonoBehaviour {
	public itemEnum reqItem;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			// the player has the required item
			if (other.gameObject.GetComponent<InventoryNew> ().itemExists ((int)reqItem) != -1)
			{
				// let the player pass
				transform.GetChild(0).transform.gameObject.SetActive(false);
			}
		}
	}
}

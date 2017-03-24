using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour {

    private InventoryNew inventory;
	// Use this for initialization
	void Start () {
        inventory = gameObject.GetComponent<InventoryNew>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            collision.gameObject.SetActive(false);
            inventory.addItem(collision.gameObject.GetComponent<PickableItem>().getId());
        }
    }
}

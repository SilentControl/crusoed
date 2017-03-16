using UnityEngine;
using System.Collections;

public class PlayerPickup : MonoBehaviour {

    public GameObject inventorySystem;
    private Inventory inventory;
	// Use this for initialization
	void Start () {
        inventory = inventorySystem.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            collision.gameObject.SetActive(false);
            inventory.addItem(collision.gameObject);
        }
    }
}

using UnityEngine;
using System.Collections;

public class FinalChestOpen : MonoBehaviour {
    public bool nearChest;
    public Collider2D player;

    // Use this for initialization
    void Start () {
        nearChest = false;
        player = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (nearChest == true && player != null)
            {
 
                InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
                if ((inventory.itemExists((int)itemEnum.SPRINGKEY) != -1) &&
                    (inventory.itemExists((int)itemEnum.SUMMERKEY) != -1) &&
                    (inventory.itemExists((int)itemEnum.AUTUMNKEY) != -1) &&
                    (inventory.itemExists((int)itemEnum.WINTERKEY) != -1))
                {
                    Debug.Log("Success!");
                }
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

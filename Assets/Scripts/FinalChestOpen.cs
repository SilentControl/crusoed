using UnityEngine;
using System.Collections;

public class FinalChestOpen : MonoBehaviour {
    public bool nearChest;
	public bool isOpen;
    public Collider2D player;
	GameObject closedChest;
	GameObject openedChest;

    // Use this for initialization
    void Start () {
        nearChest = false;
        player = null;
		isOpen = false;
		closedChest = transform.GetChild (0).gameObject;
		openedChest = transform.GetChild (1).gameObject;
		openedChest.SetActive (false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
			if (nearChest == true && player != null && isOpen == false)
            {
 
				// check if the player has got all the keys
                InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
                if ((inventory.itemExists((int)itemEnum.SPRINGKEY) != -1) &&
                    (inventory.itemExists((int)itemEnum.SUMMERKEY) != -1) &&
                    (inventory.itemExists((int)itemEnum.AUTUMNKEY) != -1) &&
                    (inventory.itemExists((int)itemEnum.WINTERKEY) != -1))
                {
					closedChest.SetActive (false);
					openedChest.SetActive (true);
					isOpen = true;

					// give kerosene to the player
					inventory.addItem((int)itemEnum.KEROSENE);
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

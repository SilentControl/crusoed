using UnityEngine;
using System.Collections;

public class SetFire : MonoBehaviour {
    public bool isOnFire;
    public bool nearFireCamp;
    public Collider2D player;
    Animator animator;
    // Use this for initialization
    void Start () {
        isOnFire = false;
        nearFireCamp = false;
        player = null;
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (nearFireCamp == true && player != null)
            {
                InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
                int stickPosition = inventory.itemExists((int)itemEnum.STICK);
                int rockPosition = inventory.itemExists((int)itemEnum.STONE);
                if (stickPosition != -1 && rockPosition!= -1 && inventory.stacks[rockPosition].size >= 2)
                {
                    inventory.removeItem(stickPosition);
					inventory.removeItem(inventory.itemExists((int)itemEnum.STONE));
					inventory.removeItem(inventory.itemExists((int)itemEnum.STONE));
                    isOnFire = true;
                    animator.SetBool("isOnFire", isOnFire);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearFireCamp = true;
            player = other;
            player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.onUnlitFirePlace);
            // set player status on fire for cook
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearFireCamp = false;
            player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.idle);
            player = null;
        }
    }
}

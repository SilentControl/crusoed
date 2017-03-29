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
                int stickPosition = inventory.itemExists(8);
                if (stickPosition != -1)
                {
                    player.gameObject.GetComponent<InventoryNew>().removeItem(stickPosition);
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
            // set player status on fire for cook
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearFireCamp = false;
            player = null;
        }
    }
}

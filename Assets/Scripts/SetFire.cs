using UnityEngine;
using System.Collections;

public class SetFire : MonoBehaviour {
    public bool isOnFire;
    public bool nearFireCamp;
    public Collider2D player;
    Animator animator;
	GameObject light;
	GameObject particles;
    // Use this for initialization
    void Start () {
        isOnFire = false;
        nearFireCamp = false;
        player = null;
        animator = GetComponent<Animator>();
		light = transform.GetChild (0).gameObject;
		light.SetActive (false);
		particles = transform.GetChild (1).gameObject;
		particles.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
			if (nearFireCamp == true && player != null && isOnFire == false)
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
					player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.onLitFirePlace);
					light.SetActive (true);
					particles.SetActive (true);
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

			if (isOnFire == false)
            	player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.onUnlitFirePlace);
			else
				player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.onLitFirePlace);
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

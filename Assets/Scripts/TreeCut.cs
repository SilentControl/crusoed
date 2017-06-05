using UnityEngine;
using System.Collections;

public class TreeCut : MonoBehaviour
{
    public bool nearTree;
    public Collider2D player;
	bool timeout;
    // Use this for initialization
    void Start()
    {
        nearTree = false;
        player = null;
		timeout = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
			if (nearTree == true && player != null && timeout == false)
            {
                InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
                if (inventory.itemExists((int)itemEnum.AXE) != -1)
                {
					int rand = Random.Range (0, 10);
					if (rand % 2 == 0)
						player.gameObject.GetComponent<InventoryNew>().addItem((int)itemEnum.STICK);
					else
						player.gameObject.GetComponent<InventoryNew>().addItem((int)itemEnum.LIANA);

					player.transform.GetChild (2).GetChild (2).GetComponent<AudioSource> ().Play ();

					timeout = true;
					StartCoroutine (DelayCollect ());
                }
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearTree = true;
            player = other;
            player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.nearTree);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearTree = false;
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

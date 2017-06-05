using UnityEngine;
using System.Collections;

public class WaterCollect : MonoBehaviour {
    public bool nearWater;
    public Collider2D player;
	bool timeout;
    // Use this for initialization
    void Start () {
        nearWater = false;
        player = null;
		timeout = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
			if (nearWater== true && player != null && timeout == false)
            {
                InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
                inventory.addItem((int)itemEnum.WATER);
				player.transform.GetChild (2).GetChild (5).GetComponent<AudioSource> ().Play ();
				timeout = true;
				StartCoroutine (DelayCollect ());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearWater = true;
            player = other;
            player.gameObject.GetComponent<PlayerStatus>().setStatus(playerPlace.onWater);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearWater = false;
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

using UnityEngine;
using System.Collections;

public class WaterCollect : MonoBehaviour {
    public bool nearWater;
    public Collider2D player;
    // Use this for initialization
    void Start () {
        nearWater = false;
        player = null;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (nearWater== true && player != null)
            {
                InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
                player.gameObject.GetComponent<InventoryNew>().addItem((int)itemEnum.WATER);
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
}

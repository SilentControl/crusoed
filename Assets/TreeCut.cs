using UnityEngine;
using System.Collections;

public class TreeCut : MonoBehaviour
{
    public bool nearTree;
    public Collider2D player;
    // Use this for initialization
    void Start()
    {
        nearTree = false;
        player = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (nearTree == true && player != null)
            {
                Debug.Log("Here1");
                InventoryNew inventory = player.gameObject.GetComponent<InventoryNew>();
                if (inventory.itemExists(115) != -1)
                {
                    Debug.Log("Here2");
                    player.gameObject.GetComponent<InventoryNew>().addItem(8);
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearTree = false;
            player = null;
        }
    }
}

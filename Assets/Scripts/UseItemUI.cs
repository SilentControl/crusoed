using UnityEngine;
using System.Collections;

public class UseItemUI : MonoBehaviour {
    public GameObject player;
    private GUISlotsManager slotsManager;
    private InventoryNew inventory;
	// Use this for initialization
	void Start () {
        slotsManager = transform.parent.GetChild(0).GetComponent<GUISlotsManager>();
        inventory = player.GetComponent<InventoryNew>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void triggerUseItem()
    {
        int selectedSlot = slotsManager.getLastSelected();
        if (selectedSlot != -1)
        {
            inventory.useItem(selectedSlot);
        }
    }
}

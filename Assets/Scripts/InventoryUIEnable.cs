using UnityEngine;
using System.Collections;

public class InventoryUIEnable : MonoBehaviour {
    bool enable = true;
    GameObject inventoryUI;
    GUISlotsManager manager;
    // Use this for initialization
    void Start () {
        inventoryUI = transform.GetChild(0).gameObject;
        inventoryUI.SetActive(enable);
        manager = transform.GetChild(0).GetChild(0).GetComponent<GUISlotsManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            enable = !enable;
            inventoryUI.SetActive(enable);
            manager.mapIcons(manager.inventory.stacks);
			manager.deselectAll ();
        }
    }
}

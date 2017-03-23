using UnityEngine;
using System.Collections;

public class InventoryUIEnable : MonoBehaviour {
    bool enable = false;
    GameObject inventoryUI;
    // Use this for initialization
    void Start () {
        inventoryUI = transform.GetChild(0).gameObject;
        inventoryUI.SetActive(enable);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I))
        {
            enable = !enable;
            inventoryUI.SetActive(enable);
            //Debug.Log("Pressed C!\n");
        }
    }
}

using UnityEngine;
using System.Collections;

public class CraftItemUI : MonoBehaviour {
    private CraftSlotsManager slotsManager;
	// Use this for initialization
	void Start () {
        slotsManager = transform.parent.GetChild(0).GetComponent<CraftSlotsManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void triggerCraftItem()
    {
        slotsManager.craftItem(slotsManager.getLastSelected());
    }
}

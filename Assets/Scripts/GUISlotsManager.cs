using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUISlotsManager : MonoBehaviour {

    int lastSelected;
    //public GameObject player;
    //InventoryNew inventory;
    // Use this for initialization
    void Start () {
        lastSelected = -1;
        //inventory = player.GetComponent<InventoryNew>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // select a child slot; deselect the previously selected
    void selectChild(int position)
    {
        //int position = System.Convert.ToInt32(msgPosition);
        if (lastSelected != -1)
        {
            transform.GetChild(lastSelected).GetComponent<GUISlotInventory>().deselect();
        }

        if (lastSelected != position)
        {
            transform.GetChild(position).GetComponent<GUISlotInventory>().select();
            lastSelected = position;
        }

        else
        {
            lastSelected = -1;
        }
    }

    // match each slot with its corresponding icon
    public void mapIcons(List<Stack> inventory)
    {
        int position = 0;
        foreach(Stack stackItem in inventory)
        {
            transform.GetChild(position).GetComponent<GUISlotInventory>().setSprite(stackItem.item.icon);
            position++;
        }
    }

    public int getLastSelected()
    {
        return lastSelected;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CraftSlotsManager : MonoBehaviour {

    int lastSelected;
    public GameObject player;
    public GameObject itemDatabase;
    InventoryNew inventory;
    List<Item> craftable;
    InfoCraftUI selectedItemInfo;
    // Use this for initialization
    void Start () {
        lastSelected = -1;
        inventory = player.GetComponent<InventoryNew>();
        craftable = itemDatabase.GetComponent<ItemCollection>().getCraftList();
        selectedItemInfo = transform.parent.GetChild(2).GetComponent<InfoCraftUI>();
        mapIcons();
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
            selectedItemInfo.updateSelectedItemInfo(null, false, false);
        }

        if (lastSelected != position)
        {
            transform.GetChild(position).GetComponent<GUISlotInventory>().select();
            lastSelected = position;

            Item item = craftable[position];
            selectedItemInfo.updateSelectedItemInfo(item, canCraft(item), true);
        }

        else
        {
            lastSelected = -1;
        }
    }

    // match each slot with its corresponding icon
    public void mapIcons()
    {
        int position = 0;
        foreach (Item item in craftable)
        {
            GUISlotInventory slot = transform.GetChild(position).GetComponent<GUISlotInventory>();//.setSprite(item.icon);
            //Sprite sprite = new Sprite();
            //slot.setSprite(sprite);
            if (slot == null)
            {
                Debug.Log("No slot!\n");
            }
            Debug.Log(" " + transform.GetChildCount());
            position++;
            Debug.Log(item.name);
        }
    }

    public int getLastSelected()
    {
        return lastSelected;
    }

    // check if the required ingredients are in the inventory
    public bool canCraft(Item item)
    {
        bool enoughResources = false;
        int resourcesFound = 0;

        CraftRecipe recipe = item.gameItemObject.GetComponent<CraftRecipe>();

        foreach(Stack stack in inventory.stacks)
        {
            foreach(ItemNo itemReq in recipe.requiredItems)
            {
                if (stack.item.getId() == itemReq.id && stack.size == itemReq.quantity)
                {
                    resourcesFound++;
                }
            }
        }

        if (resourcesFound == recipe.requiredItems.Count)
        {
            enoughResources = true;
        }

        return enoughResources;
    }
}

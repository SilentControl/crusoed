using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CraftSlotsManager : MonoBehaviour {

    int lastSelected;
    public GameObject player;
    public GameObject itemDatabase;

	PlayerStatus playerStatus;
    InventoryNew inventory;
    List<Item> craftable;
    InfoCraftUI selectedItemInfo;
    // Use this for initialization
    void Start () {
        lastSelected = -1;
        inventory = player.GetComponent<InventoryNew>();
        craftable = itemDatabase.GetComponent<ItemCollection>().getCraftList();
        selectedItemInfo = transform.parent.GetChild(2).GetComponent<InfoCraftUI>();
		playerStatus = player.GetComponent<PlayerStatus> ();
    }
	
	// Update is called once per frame
	void Update () {
        mapIcons();
    }

    // select a child slot; deselect the previously selected
    void selectChild(int position)
    {
        //mapIcons();
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
           transform.GetChild(position).GetComponent<GUISlotInventory>().setSprite(item.icon);
           position++;
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

        foreach (ItemNo itemReq in recipe.requiredItems)
        {
			
            int position = inventory.itemExists(itemReq.id);
            if (position != -1)
            {
                if (inventory.stacks[position].size >= itemReq.quantity)
                {
                    resourcesFound++;
                }
            }
        }

        if (resourcesFound == recipe.requiredItems.Count)
        {
            enoughResources = true;
        }

		if (recipe.place != playerPlace.idle)
		{
			if (recipe.place != playerStatus.getStatus ())
			{
				enoughResources = false;
			}
		}

        return enoughResources;
    }

    public void craftItem(int position)
    {
        if (canCraft(craftable[position]))
        {
            CraftRecipe recipe = craftable[position].gameItemObject.GetComponent<CraftRecipe>();
			if (recipe.manuallyCraft == true)
			{
				foreach (ItemNo itemReq in recipe.requiredItems) {
					int pos = inventory.itemExists (itemReq.id);
					for (int i = 0; i < itemReq.quantity; i++) {
						inventory.removeItem (pos);
					}
				}

				inventory.addItem (craftable [position].id);
			}
        }
    }
}

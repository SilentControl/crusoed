using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum itemEnum
{
    CARROT,
    CHERRY,
    EGGPLANT,
    LEMON,
    LIME,
    MUSHROOM,
    WATERMELON,
    STONE,
    STICK,
    APPLE,
    BANANA,
    PEAR,
    TOMATO,
    PUMPKIN,
    WATER,
    RAWMEAT,
    COOKEDMEAT,
    LEMONADE,
    LIMEONADE,
    RAWFISH,
    COOKEDFISH,
    IRON,
    LIANA,
    FIRE,
    AXE,
    SPEAR,
    HAMMER,
    SHOVEL,
    PICKAXE,
    SWORD,
    STEEL,
    SPRINGKEY,
    SUMMERKEY,
    AUTUMNKEY,
    WINTERKEY,
    JACKOLANTERN,
	ROD,
	REPAIRBRIDGE,
	METALBOOTS,
	BLUECRYSTAL,
	GREENCRYSTAL,
	PURPLECRYSTAL,
	SCROLL,
	KEROSENE,
	AIRPLANE
}


public class InventoryNew : MonoBehaviour {

    public List<Stack> stacks;
    public GameObject itemDatabase;
    public GameObject inventoryUI;
    private ItemCollection itemCollection;
    private GUISlotsManager slotsManager;
    private PlayerStats playerStats;
	private ActionBubble actionBubble;
	public AudioSource pickup;
	public AudioSource pickupKey;
    // Use this for initialization
    void Start () {
        playerStats = gameObject.GetComponent<PlayerStats>();
		actionBubble = gameObject.GetComponent<ActionBubble> ();
        itemCollection = itemDatabase.GetComponent<ItemCollection>();
        slotsManager = inventoryUI.transform.GetChild(0).GetChild(0).GetComponent<GUISlotsManager>();
        stacks = new List<Stack>();
        //addItem(0);
        //addItem(1);
        //addItem(1);
       // addItem(1);
        //addItem(0);
        printInventory();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // remove a stack from the inventory
    public void removeStack(int position)
    {
        stacks.RemoveAt(position);
        slotsManager.transform.GetChild(position).GetComponent<GUISlotInventory>().setDefaultSprite();
        slotsManager.mapIcons(stacks);
    }

    // remove an item from a stack
    public void removeItem(int position)
    {
        Stack itemStack = stacks[position];
        if (itemStack != null)
        {
            itemStack.size--;
            if (itemStack.size <= 0)
            {
                removeStack(position);
            }
        }
    }

    public int itemExists(int id)
    {
        int position = 0;
        foreach (Stack stack in stacks)
        {
            if (stack.item.getId() == id)
            {
                return position;
            }

            position++;
        }

        position = -1;
        return position;
    }

    public void addItem(int id)
    {
        int position = itemExists(id);
        if (position == -1)
        {
            stacks.Add(new Stack(itemCollection.itemDictionary[id], 1));
            slotsManager.mapIcons(stacks);
        }

        else
        {
            Stack itemStack = stacks[position];
            itemStack.size++;
        }

		actionBubble.showBubble (itemCollection.itemDictionary [id].icon);
		if (id == (int)itemEnum.SPRINGKEY || id == (int)itemEnum.SUMMERKEY || id == (int)itemEnum.AUTUMNKEY || id == (int)itemEnum.WINTERKEY)
			pickupKey.Play ();
		else
			pickup.Play ();
    }

    public void useItem(int position)
    {
        if (position < stacks.Count)
        {
            Stack itemStack = stacks[position];
            Item item = itemStack.item;
			if (item.type == ItemType.Food) {
				Food healItem = item.gameItemObject.GetComponent<Food> ();
				playerStats.modifyHunger (healItem.getHungerValue ());
				playerStats.modifyHealth (healItem.getHealthValue ());
				playerStats.modifyThirst (healItem.getThirstValue ());

				removeItem (position);
				slotsManager.mapIcons (stacks);
			} else {
				if (item.getId () == (int)itemEnum.AIRPLANE)
				{
					GameObject airplane = Instantiate (item.gameItemObject);
					airplane.transform.position = new Vector3 (69.03f, -85.13f, gameObject.transform.position.z);
				}
			}
        }
    }

    public void printInventory()
    {
        int position = 0;
        foreach (Stack stack in stacks)
        {
            Debug.Log("#" + position + " " + stack.item.name + " " + stack.size);
            position++;
        }
    }
}

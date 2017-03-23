using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryNew : MonoBehaviour {

    private List<Stack> stacks;
    public GameObject itemDatabase;
    private ItemCollection itemCollection;

    // Use this for initialization
    void Start () {
        itemCollection = itemDatabase.GetComponent<ItemCollection>();
        stacks = new List<Stack>();
        addItem(0);
        addItem(1);
        addItem(1);
        addItem(1);
        addItem(0);
        printInventory();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // remove a stack from the inventory
    public void removeStack(int position)
    {
        stacks.RemoveAt(position);
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
        }

        else
        {
            Stack itemStack = stacks[position];
            itemStack.size++;
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

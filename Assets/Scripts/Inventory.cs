﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    // change to KeyValuePair<Food, int> etc
    public Dictionary<string, KeyValuePair<Food, int>> food;
    public Dictionary<string, KeyValuePair<Tool, int>> tools;
    public Dictionary<string, KeyValuePair<Weapon, int>> weapons;
    public Dictionary<string, KeyValuePair<Misc, int>> misc;
    public enum enumItemType
    {
        FOOD,
        TOOLS,
        WEAPONS,
        MISC
    };

    public GameObject player;
    public PlayerStats playerStats;
    // Use this for initialization
    void Start () {
        playerStats = player.GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    // Add a picked up item to the corresponding dictionary
    public void addItem(GameObject item)
    {
        PickableItem pickedItem = item.GetComponent<PickableItem>();
        switch (pickedItem.itemType)
        {
            case (int)enumItemType.FOOD:
                Food foodItem = item.GetComponent<Food>();
                if (food.ContainsKey(foodItem.foodName))
                {
                    KeyValuePair<Food, int> entry = food[foodItem.foodName];
                    int total = entry.Value;
                    food[foodItem.foodName] = new KeyValuePair<Food, int>(entry.Key, total);
                }

                else
                    food.Add(foodItem.foodName, new KeyValuePair<Food, int>(item.GetComponent<Food>(), 0));
                break;

            case (int)enumItemType.TOOLS:
                Tool toolItem = item.GetComponent<Tool>();
                if (tools.ContainsKey(toolItem.toolName))
                {
                    KeyValuePair<Tool, int> entry = tools[toolItem.toolName];
                    int total = entry.Value;
                    tools[toolItem.toolName] = new KeyValuePair<Tool, int>(entry.Key, total);
                }

                else
                    tools.Add(toolItem.toolName, new KeyValuePair<Tool, int>(item.GetComponent<Tool>(), 0));
                break;

            case (int)enumItemType.WEAPONS:
                Weapon weaponItem = item.GetComponent<Weapon>();
                if (weapons.ContainsKey(weaponItem.weaponName))
                {
                    KeyValuePair<Weapon, int> entry = weapons[weaponItem.weaponName];
                    int total = entry.Value;
                    weapons[weaponItem.weaponName] = new KeyValuePair<Weapon, int>(entry.Key, total);
                }

                else
                    weapons.Add(weaponItem.weaponName, new KeyValuePair<Weapon, int>(item.GetComponent<Weapon>(), 0));
                break;

            case (int)enumItemType.MISC:
                Misc miscItem = item.GetComponent<Misc>();
                if (misc.ContainsKey(miscItem.miscName))
                {
                    KeyValuePair<Misc, int> entry = misc[miscItem.miscName];
                    int total = entry.Value;
                    misc[miscItem.miscName] = new KeyValuePair<Misc, int>(entry.Key, total);
                }

                else
                    misc.Add(miscItem.miscName, new KeyValuePair<Misc, int>(item.GetComponent<Misc>(), 0));
                break;

            default:
                break;
        }
    }

    // Use food to heal and to satisfy hunger
    public int healFood(string foodName)
    {
        KeyValuePair<Food, int> foodStack = food[foodName];
        Food foodItem = foodStack.Key.GetComponent<Food>();
        int total = foodStack.Value;

        playerStats.modifyHunger(foodItem.getHungerValue());
        playerStats.modifyHealth(foodItem.getHealthValue());

        total--;
        if (total == 0)
        {
            food.Remove(foodName);
            return 0;
        }

        else
        {
            food[foodName] = new KeyValuePair<Food, int>(foodItem, total);
            return total;
        }

    }
}

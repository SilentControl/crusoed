using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    // change to KeyValuePair<Food, int> etc
    public Dictionary<string, KeyValuePair<GameObject, int>> food;
    public Dictionary<string, KeyValuePair<GameObject, int>> tools;
    public Dictionary<string, KeyValuePair<GameObject, int>> weapons;
    public Dictionary<string, KeyValuePair<GameObject, int>> misc;
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
                    KeyValuePair<GameObject, int> entry = food[foodItem.foodName];
                    int total = entry.Value;
                    food[foodItem.foodName] = new KeyValuePair<GameObject, int>(item, total);
                }

                else
                    food.Add(foodItem.foodName, new KeyValuePair<GameObject, int>(item, 0));
                break;
            default:
                break;
        }
    }

    // Use food to heal and to satisfy hunger
    public int healFood(string foodName)
    {
        KeyValuePair<GameObject, int> foodStack = food[foodName];
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
            //food[foodName] = new KeyValuePair<GameObject, int>(foodItem, total);
            return total;
        }

    }
}

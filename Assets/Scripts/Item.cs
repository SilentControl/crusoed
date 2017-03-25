using UnityEngine;
using System.Collections;

public enum ItemType
{
    Food,
    Tool,
    Weapon,
    Misc
}

[System.Serializable]
public class Item
{
    public string name;
    public int id;
    public string description;
    public ItemType type;
    public bool isCraftable;

    public GameObject gameItemObject;
    public Sprite icon;

    public int getId()
    {
        return id;
    }
}

[System.Serializable]
public class Stack
{
    public Item item;
    public int size;

    public Stack(Item item, int size)
    {
        this.item = item;
        this.size = size;
    }
}
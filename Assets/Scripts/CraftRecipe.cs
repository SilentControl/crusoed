using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ItemNo
{
    public string name;
    public int id;
    public int quantity;
}


public class CraftRecipe : MonoBehaviour {
    public playerPlace place;
    public List<ItemNo> requiredItems;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

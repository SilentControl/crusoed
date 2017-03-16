using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIInventory : MonoBehaviour {

    private Rect inventoryWindow = new Rect(0, 0, 400, 400);
    private bool inventoryActive = false;
    public GameObject inventorySystem;
    private Inventory inventory;
	// Use this for initialization
	void Start () {
        inventory = inventorySystem.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnGUI()
    {
        inventoryActive = GUI.Toggle(new Rect(40, 80, 100, 50), inventoryActive, "Inventory");

        if (inventoryActive)
        {
            inventoryWindow = GUI.Window(0, inventoryWindow, drawWindow, "Inventory");
        }
    }

    void drawWindow(int windowID)
    {
        Dictionary<string, KeyValuePair<Food, int>> food = inventory.food;

        GUILayout.BeginArea(new Rect(0, 0, 400, 400));

        int count = 0;

        foreach (KeyValuePair<string, KeyValuePair<Food, int>> entry in food)
        {
            string itemName = entry.Key;
            int total = entry.Value.Value;

            if (count % 3 == 0)
            {
                GUILayout.BeginHorizontal();
            }

            GUILayout.Button(itemName + ": " + total.ToString(), GUILayout.Width(100), GUILayout.Height(50));

            count++;
            if (count % 3 == 0)
            {
                GUILayout.EndHorizontal();
            }
        }

       /* GUILayout.BeginHorizontal();
        GUILayout.Button("Item 1", GUILayout.Height(50));
        GUILayout.Button("Item 2", GUILayout.Height(50));
        GUILayout.Button("Item 3", GUILayout.Height(50));
        GUILayout.EndHorizontal();*/

        /*GUILayout.BeginHorizontal();
        GUILayout.Button("Item 4", GUILayout.Height(50));
        GUILayout.Button("Item 5", GUILayout.Height(50));
        GUILayout.Button("Item 6", GUILayout.Height(50));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button("Item 7", GUILayout.Height(50));
        GUILayout.Button("Item 8", GUILayout.Height(50));
        GUILayout.Button("Item 9", GUILayout.Height(50));
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Button("Item 10", GUILayout.Height(50));
        GUILayout.Button("Item 11", GUILayout.Height(50));
        GUILayout.Button("Item 12", GUILayout.Height(50));
        GUILayout.EndHorizontal();*/

        GUILayout.EndArea();
    }
}

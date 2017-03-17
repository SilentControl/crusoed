using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CraftingItem : MonoBehaviour {

    public GameObject inventSystem;
    private Inventory inventory;
    public ArrayList require = new ArrayList();
    public List<string> list = new List<string>();
	// Use this for initialization
	void Start () {
        inventory = inventSystem.GetComponent<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {
        // change pic if cannot build
        bool canBuild = true;
        foreach (string reqItem in list)
        {
            if (!inventory.contains(reqItem))
            {
                canBuild = false;
                break;
            }
        }

        if (canBuild == true)
        {
            transform.GetChild(1).GetComponent<Image>().color = new UnityEngine.Color(0xff, 0xff, 0xff, 0xff);
        }

        else
        {
            transform.GetChild(1).GetComponent<Image>().color = new UnityEngine.Color(0x00, 0x00, 0x00, 0xff);
        }
	}

    private void OnMouseDown()
    {

    }
}

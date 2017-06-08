using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoInventoryUI : MonoBehaviour {
    Text totalStack;
    Text description;
	// Use this for initialization
	void Start () {
        totalStack = transform.GetChild(0).GetComponent<Text>();
        description = transform.GetChild(1).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    // updates the information about the selected item from the inventory
    public void updateSelectedItemInfo(int number, string description)
    {
        if (number > 0)
        {
            totalStack.text = "Stack total: " + number;
            this.description.text = description;
        }

        else
        {
            totalStack.text = "";
            this.description.text = "";
        }
    }

	public void clearInfo()
	{
		totalStack.text = "";
		this.description.text = "";
	}
}

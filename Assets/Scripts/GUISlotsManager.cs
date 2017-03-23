using UnityEngine;
using System.Collections;

public class GUISlotsManager : MonoBehaviour {

    int lastSelected;
    // Use this for initialization
    void Start () {
        lastSelected = -1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void selectChild(int position)
    {
        //int position = System.Convert.ToInt32(msgPosition);
        if (lastSelected != -1)
        {
            transform.GetChild(lastSelected).GetComponent<GUISlotInventory>().deselect();
        }

        if (lastSelected != position)
        {
            transform.GetChild(position).GetComponent<GUISlotInventory>().select();
            lastSelected = position;
        }

        else
        {
            lastSelected = -1;
        }
    }
}

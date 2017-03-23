using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUISlotInventory : MonoBehaviour {

    private Color selectedCol;
    private Color deselectedCol;
    public int position;
    // Use this for initialization
	void Start () {
        Color slotColor = gameObject.GetComponent<Image>().color;
        deselectedCol = new Color(slotColor.r, slotColor.g, slotColor.b, slotColor.a);
        selectedCol = new Color(slotColor.r, slotColor.g, slotColor.b, 255.0f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void select()
    {
        gameObject.GetComponent<Image>().color = selectedCol;
    }

    public void deselect()
    {
        gameObject.GetComponent<Image>().color = deselectedCol;
    }

    public void onClickAction()
    {
        SendMessageUpwards("selectChild", position);
    }
}

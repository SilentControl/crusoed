using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUISlotInventory : MonoBehaviour {

    private Color selectedCol;
    private Color deselectedCol;
    public int position;
    public Sprite defaultSprite;
    private Image icon;
    // Use this for initialization
	void Start () {
        icon = gameObject.GetComponent<Image>();
        defaultSprite = icon.sprite;
        Color slotColor = icon.color;
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

    public void setSprite(Sprite sprite)
    {
        icon.sprite = sprite;
    }

    public void setDefaultSprite()
    {
        icon.sprite = defaultSprite;
    }
}

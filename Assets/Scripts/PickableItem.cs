using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

    public string itemName;
    public enum enumItemType
    {
        FOOD,
        TOOLS,
        WEAPONS,
        MISC
    };

    public int itemType;
	// Use this for initialization
	void Start ()
    {
        itemName = "genericItem";
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}

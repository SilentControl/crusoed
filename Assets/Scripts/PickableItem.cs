using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

    public string itemName;
    public int id;
    public ItemType itemType;
	// Use this for initialization
	void Start ()
    {
	}

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
        }
    }*/

    // Update is called once per frame
    void Update ()
	{
	}

    public int getId()
    {
        return id;
    }
}

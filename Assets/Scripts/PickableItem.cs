using UnityEngine;
using System.Collections;

public class PickableItem : MonoBehaviour {

    public string itemName;
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

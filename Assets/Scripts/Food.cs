using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public int healthValue;
    public int hungerValue;
    public string foodName;

	// Use this for initialization
	void Start () {
        healthValue = 20;
        hungerValue = -25;
        foodName = "defaultFood";
	}

    public int getHealthValue()
    {
        return healthValue;
    }

    public int getHungerValue()
    {
        return hungerValue;
    }


    // Update is called once per frame
    void Update () {
	
	}
}

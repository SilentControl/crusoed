using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public int healthValue;
    public int hungerValue;
	public int thirstValue;
    public string foodName;

	// Use this for initialization
	void Start () {
	}

    public int getHealthValue()
    {
        return healthValue;
    }

    public int getHungerValue()
    {
        return hungerValue;
    }

	public int getThirstValue()
	{
		return thirstValue;
	}


    // Update is called once per frame
    void Update () {
	
	}
}

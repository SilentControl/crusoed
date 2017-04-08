using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int hunger;
    public int thirst;
    public int ticks;
	// Use this for initialization
	void Start ()
    {
        health = 100;
        hunger = thirst = ticks = 0;
	}

    public void modifyHealth(int value)
    {
        health += value;
        if (health >= 100)
            health = 100;
        if (health <= 0)
            health = 0;
    }

    public void modifyHunger(int value)
    {
        hunger += value;
        if (hunger >= 100)
            hunger = 100;
        if (hunger <= 0)
            hunger = 0;
    }

    public void modifyThirst(int value)
    {
        thirst += value;
        if (thirst >= 100)
            thirst = 100;
        if (thirst <= 0)
            thirst = 0;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        ticks++;
        if (ticks % 300 == 0)
        {
            hunger++;
            thirst += 2;

            if (hunger >= 100)
            {
                health--;
                hunger = 100;
            }

            if (thirst >= 100)
            {
                health -= 2;
                thirst = 100;
            }
        }
	}
}

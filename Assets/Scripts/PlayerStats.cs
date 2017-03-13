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
        health = hunger = thirst = 100;
        ticks = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        ticks++;
        if (ticks % 100 == 0)
        {
            hunger--;
            thirst -= 2;

            if (hunger < 0)
            {
                health--;
                hunger = 0;
            }

            if (thirst < 0)
            {
                health -= 2;
                thirst = 0;
            }
        }
	}
}

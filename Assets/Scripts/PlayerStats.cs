using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStats : MonoBehaviour
{
    public int health;
    public int hunger;
    public int thirst;
    public int ticks;
	public int deaths;

	public GameObject deathCounter;
	public GameObject leftFirstIsland;

	const float spawnPointX = 82.0f;
	const float spawnPointY = -131.0f;
	Vector3 checkpoint;
	Vector3 startIsland;
	// Use this for initialization
	void Start ()
    {
        health = 100;
        hunger = thirst = ticks = 0;
		deaths = 0;
		checkpoint = new Vector3 (spawnPointX, spawnPointY, 0.0f);
		startIsland = new Vector3 (23.3f, -6.2f, 0.0f);

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

	bool winterConditions()
	{
		return (gameObject.transform.position.x >= 555.0f &&
				gameObject.transform.position.x <= 648.3f &&
				gameObject.transform.position.y < -92.0f &&
				gameObject.transform.position.y >= -148.35);
	}

    // Update is called once per frame
    void FixedUpdate ()
    {
        ticks++;
        if (ticks % 300 == 0)
        {
            hunger++;
            thirst++;

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

			if (winterConditions() == true) {
				health--;
			}

			// the player dies
			if (health <= 0)
			{
				deaths++;
				if (leftFirstIsland.transform.GetChild (0).gameObject.GetComponent<SetFire> ().isOnFire == true)
					gameObject.transform.position = checkpoint;
				else
					gameObject.transform.position = startIsland;
				health = 100;
				thirst = hunger = 0;
				deathCounter.transform.GetChild(0).GetComponent<Text> ().text = ": " + deaths;
			}
        }
	}
}

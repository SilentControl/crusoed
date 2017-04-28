using UnityEngine;
using System.Collections;

public class PlayerSleep : MonoBehaviour {

	// Use this for initialization
	public GameObject sun;
	public GameObject sleepUI;

	DayNight sunLight;
	PlayerStats stats;
	PlayerStatus location;
	void Start () {
		sunLight = sun.GetComponent<DayNight> ();
		stats = gameObject.GetComponent<PlayerStats> ();
		location = gameObject.GetComponent<PlayerStatus> ();
	}
	
	// Update is called once per frame
	void Update () {
		// if the player wants to sleep
		if (Input.GetKeyUp (KeyCode.Z))
		{
			
			// set the time to morning
			sunLight.goMorning ();

			// show the ZZZ... screen
			StartCoroutine (Wait ());

			// if the player doesn't sleep near a fireplace, deduct his life 
			if (location.getStatus () != playerPlace.onLitFirePlace)
			{
				int health = stats.health;
				health /= 2;
				stats.health = health;
			}
		}
	}

	IEnumerator Wait()
	{
		sleepUI.transform.GetChild (0).gameObject.SetActive (true);
		yield return new WaitForSecondsRealtime (1.5f);
		sleepUI.transform.GetChild (0).gameObject.SetActive (false);
	}
}

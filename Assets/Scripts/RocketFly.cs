
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RocketFly : MonoBehaviour {
	bool nearRocket;
	public bool launched;
	bool displayedEnd;
	public Collider2D player;
	Vector3 newposition;
	float distance;
	int deaths;
	GameObject fireworks;
	AudioSource fireworkSound;
	// Use this for initialization
	void Start () {
		nearRocket = false;
		launched = false;
		displayedEnd = false;
		newposition = new Vector3 ();
		distance = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.E))
		{
			if (nearRocket == true && player != null)
			{
				// hide the player; he enters the rocket
				deaths = player.gameObject.GetComponent<PlayerStats>().deaths;
				player.gameObject.SetActive (false);
				launched = true;
				fireworks = GameObject.Find ("FireworkSystem");
				fireworks.transform.GetChild (0).gameObject.SetActive (true);
				fireworkSound = GameObject.Find("FireworkSound").GetComponent<AudioSource>();
				AudioSource endMusic = GameObject.Find("EndSound").GetComponent<AudioSource>();
				endMusic.loop = true;
				endMusic.Play ();
				fireworkSound.loop = true;
				fireworkSound.Play ();
			}
		}

		// the rocket has been launched; increase it's y-coord
		if (launched == true)
		{
			newposition = transform.position;
			newposition.y += 5.0f * Time.deltaTime;
			transform.position = newposition;
			distance += 5.0f * Time.deltaTime;

			if (displayedEnd == false)
			{
				// show the ending screen
				GameObject ending = GameObject.Find ("Ending");
				if (ending)
				{
					ending.transform.GetChild (0).gameObject.SetActive (true);
					ending.transform.GetChild (0).GetChild (0).GetComponent<Text> ().text += deaths;

					DayNight daynight = GameObject.Find ("Sun").GetComponent<DayNight> ();
					ending.transform.GetChild (0).GetChild (2).GetComponent<Text> ().text += daynight.days;

					if (daynight.days <= 5 && deaths <= 0) 
					{
						ending.transform.GetChild (0).GetChild (3).GetComponent<Text> ().text += "Superman";
					}

					else
					if (daynight.days <= 10 && deaths > 0 && deaths < 3) 
					{
						ending.transform.GetChild (0).GetChild (3).GetComponent<Text> ().text += "Very good";
					}		

					else
					if (daynight.days > 10 && deaths > 3 && deaths < 7) 
					{
						ending.transform.GetChild (0).GetChild (3).GetComponent<Text> ().text += "Average";
					}

					else
						ending.transform.GetChild (0).GetChild (3).GetComponent<Text> ().text += "Slowpoke";

					displayedEnd = true;
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearRocket= true;
			player = other;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			nearRocket = false;
			player = null;
		}
	}
}

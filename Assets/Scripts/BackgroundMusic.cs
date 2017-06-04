using UnityEngine;
using System.Collections;

public class BackgroundMusic : MonoBehaviour {
	public AudioSource mainIsland;
	public AudioSource springIsland;
	public AudioSource summerIsland;
	public AudioSource autumnIsland;
	public AudioSource winterIsland;

	AudioSource lastPlayed;
	AudioSource toPlay;
	// Use this for initialization
	void Start () {
		mainIsland.Play ();
		lastPlayed = mainIsland;
	}

	void updateTrack()
	{
		float x = transform.position.x;
		float y = transform.position.y;

		if (y < 0 && y > -170 && x > -35 && x < 114)
			toPlay = mainIsland;

		if (y < -62 && y > -182)
		{
			if (x > 128 && x < 231)
				toPlay = springIsland;
			if (x > 268 && x < 378)
				toPlay = summerIsland;
			if (x > 410 && x < 514)
				toPlay = autumnIsland;
			if (x > 540 && x < 656)
				toPlay = winterIsland;			
				
		}

		if (toPlay != lastPlayed)
		{
			lastPlayed.Stop ();
			lastPlayed = toPlay;
			toPlay.Play ();
		}
	}

	// Update is called once per frame
	void Update () {
		updateTrack ();
	}
}

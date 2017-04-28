using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {
	Light sun;
	int ticks = 0;
	bool increaseLight = false;
	// Use this for initialization
	void Start () {
		sun = gameObject.GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		ticks++;
		if (ticks % 500 == 0)
		{
			ticks = 0;

			float intensity = sun.intensity;
			if (intensity >= 1.0f)
			{
				increaseLight = false;
			}

			if (intensity <= 0.01f)
			{
				increaseLight = true;
			}

			if (increaseLight == true)
				intensity += 0.01f;
			else
				intensity -= 0.01f;
			sun.intensity = intensity;
		}
	}

	public void increaseTheLight()
	{
		increaseLight = true;
	}

	public void goMorning()
	{
		sun.intensity = 0.79f;
	}
}

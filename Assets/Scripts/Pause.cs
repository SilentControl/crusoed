using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	bool paused = false;
	GameObject pauseInterface;
	void Start()
	{
		pauseInterface = transform.GetChild (0).gameObject;
		pauseInterface.SetActive (paused);
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = togglePause ();
			pauseInterface.SetActive (paused);
		}
	}

/*	void OnGUI()
	{
		if(paused)
		{
			GUILayout.Label("Game is paused!");
			if(GUILayout.Button("Click me to unpause"))
				paused = togglePause();
		}
	}*/

	public void mainMenu()
	{
		paused = togglePause ();
		Application.LoadLevel(0);
	}

	public void resume()
	{
		paused = togglePause();
		pauseInterface.SetActive (paused);
	}

	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			return(true);    
		}
	}
}

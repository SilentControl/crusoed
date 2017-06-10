using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour {
	GameObject demonHorde;
	Camera mycamera;
	float decr = 0.05f;
	Vector3 newposition;
	int k = 0;
	int demonChildCount;
	// Use this for initialization
	void Start () {
		demonHorde = GameObject.Find ("Horde");
		newposition = new Vector3 (0.0f, 0.0f, 0.0f);
		demonChildCount = demonHorde.transform.childCount;
		mycamera = transform.GetChild (0).GetComponent<Camera> ();
	}

	IEnumerator Waiter()
	{
		yield return new WaitForSecondsRealtime (0.5f);

	}

	IEnumerator Waiter2()
	{
		yield return new WaitForSecondsRealtime (2.0f);
		Application.LoadLevel (0);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y > -191.0f) {
			newposition = transform.position;
			newposition.y = newposition.y - decr;
			transform.position = newposition;
		}

		else
		{
			if (k < demonChildCount)
			{
				demonHorde.transform.GetChild (k).gameObject.SetActive (true);
				k++;
				StartCoroutine(Waiter());
			}
				
			float camsize = mycamera.orthographicSize;

			if (camsize < 37.7f) {
				camsize = camsize + 0.1f;
				mycamera.orthographicSize = camsize;
			} else {
				StartCoroutine (Waiter2 ());
			}
		}
	}
}

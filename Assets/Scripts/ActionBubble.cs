using UnityEngine;
using System.Collections;

public class ActionBubble : MonoBehaviour {
	GameObject bubble;
	// Use this for initialization
	void Start () {
		bubble = transform.GetChild (0).gameObject;
		bubble.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showBubble(Sprite sprite)
	{
		StartCoroutine (bubbleTime (sprite));
	}

	IEnumerator bubbleTime(Sprite sprite)
	{
		bubble.SetActive (true);
		bubble.transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = sprite;
		yield return new WaitForSecondsRealtime (1.5f);
		bubble.SetActive (false);
	}
}

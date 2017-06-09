using UnityEngine;
using System.Collections;

public class DamagePlayer : MonoBehaviour {
	public int damage = 0;
	public bool destroyOnCol = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerStats> ().modifyHealth (-damage);
			if (damage > 0)
				other.gameObject.transform.GetChild (2).GetChild (4).GetComponent<AudioSource> ().Play ();
			if (destroyOnCol == true)
				gameObject.SetActive (false);
		}
	}
}

using UnityEngine;
using System.Collections;

public class DamagePlayerOnCol : MonoBehaviour {
	public int damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Player")
		{
			coll.gameObject.GetComponent<PlayerStats> ().modifyHealth (-damage);
			coll.gameObject.transform.GetChild (2).GetChild (4).GetComponent<AudioSource> ().Play ();
		}
	}
}

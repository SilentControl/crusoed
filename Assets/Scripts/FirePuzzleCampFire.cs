using UnityEngine;
using System.Collections;

public class FirePuzzleCampFire : MonoBehaviour {
	FirePuzzle firePuzzleManager;
	// Use this for initialization
	void Start () {
		firePuzzleManager = gameObject.GetComponentInParent<FirePuzzle>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

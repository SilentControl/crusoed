using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CraftSystem : MonoBehaviour {

    public Dictionary<string, KeyValuePair<string, int>[]> buildReqs;
    

	// Use this for initialization
	void Start () {
        buildReqs = new Dictionary<string, KeyValuePair<string, int>[]>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GUIUpdatePlayerStats : MonoBehaviour {
    public GameObject player;
    private Slider[] sliders;
    private PlayerStats playerStats;

	// Use this for initialization
	void Start () {
       sliders = GetComponentsInChildren<Slider>();
        playerStats = player.GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        sliders[0].value = playerStats.health;
        sliders[1].value = playerStats.hunger;
        sliders[2].value = playerStats.thirst;
    }
}

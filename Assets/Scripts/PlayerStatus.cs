﻿using UnityEngine;
using System.Collections;

public enum playerPlace
{
    idle,
    onLitFirePlace,
    onUnlitFirePlace,
    onWater,
    nearTree,
	nearRock,
	nearFishSpot,
	nearAnvil,
	nearBridge,
    onSpecialForge
}

public class PlayerStatus : MonoBehaviour {
	public playerPlace status;

	// Use this for initialization
	void Start () {
        status = playerPlace.idle;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setStatus(playerPlace newPlace)
    {
        status = newPlace;
    }

	public playerPlace getStatus()
	{
		return status;
	}
}

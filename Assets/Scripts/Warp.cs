using UnityEngine;
using System.Collections;

public enum warpDirection
{
	DOWN,
	UP,
	LEFT,
	RIGHT
}

public class Warp : MonoBehaviour {
	public warpDirection direction;
	public GameObject destination;
	Vector3 destinationPosition;
	float destinationOffset;
	// Use this for initialization
	void Start () {
		destinationPosition = destination.transform.position;
		destinationOffset = 2.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			switch (direction)
			{
				case warpDirection.DOWN:
				other.gameObject.transform.position = new Vector3 (destinationPosition.x, destinationPosition.y - destinationOffset, destinationPosition.z);
					break;
				case warpDirection.UP:
				other.gameObject.transform.position = new Vector3 (destinationPosition.x, destinationPosition.y + destinationOffset, destinationPosition.z);
					break;			
				case warpDirection.RIGHT:
				other.gameObject.transform.position = new Vector3 (destinationPosition.x + destinationOffset, destinationPosition.y , destinationPosition.z);
					break;	
				case warpDirection.LEFT:
				other.gameObject.transform.position = new Vector3 (destinationPosition.x - destinationOffset, destinationPosition.y, destinationPosition.z);
					break;
				default:
					break;
			}
		}
	}
}

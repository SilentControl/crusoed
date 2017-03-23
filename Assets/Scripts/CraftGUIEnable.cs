using UnityEngine;
using System.Collections;

public class CraftGUIEnable : MonoBehaviour {
    bool enable = false;
    GameObject craftGUI;
	// Use this for initialization
	void Start () {
        craftGUI = transform.GetChild(0).gameObject;
        craftGUI.SetActive(enable);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            enable = !enable;
            craftGUI.SetActive(enable);
            //Debug.Log("Pressed C!\n");
        }

    }
}

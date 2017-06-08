using UnityEngine;
using System.Collections;

public class CraftGUIEnable : MonoBehaviour {
    bool enable = true;
    // Use this for initialization
    GameObject background;
	void Start () {
        background = transform.GetChild(0).gameObject;
        background.SetActive(enable);
		enable = !enable;
		background.SetActive(enable);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.C))
        {
            enable = !enable;
            if (enable)
            {
                //background.transform.GetChild(0).GetComponent<CraftSlotsManager>().mapIcons();
            }
            background.SetActive(enable);
			if (enable == true)
			{
				//background.transform.GetChild (2).transform.gameObject.GetComponent<InfoCraftUI> ().clearText ();
				CraftSlotsManager manager = background.transform.GetChild (0).transform.gameObject.GetComponent<CraftSlotsManager>();
				manager.deselectAll ();
			}
            //Debug.Log("Pressed C!\n");
        }

    }
}

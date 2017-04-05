using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoCraftUI : MonoBehaviour {
    Text description;
    Text reqItem1;
    Text reqItem2;
    Text canCraft;
	// Use this for initialization
	void Start () {
	    description = transform.GetChild(0).GetComponent<Text>();
        reqItem1 = transform.GetChild(1).GetComponent<Text>();
        reqItem2 = transform.GetChild(2).GetComponent<Text>();
        canCraft = transform.GetChild(3).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateSelectedItemInfo(Item craftable, bool enoughRes, bool selected)
    {
        /*if (selected == false)
        {
            description.text = "";
            reqItem1.text = "";
            reqItem2.text = "";
            canCraft.text = "";
        }

        else
        {
            CraftRecipe recipe = craftable.gameItemObject.GetComponent<CraftRecipe>();
            description.text = craftable.description;
            reqItem1.text = recipe.requiredItems[0].name + " x " + recipe.requiredItems[0].quantity;
            reqItem2.text = recipe.requiredItems[1].name + " x " + recipe.requiredItems[1].quantity;
            
            if (enoughRes == true)
            {
                canCraft.text = "Can Craft: Yes";
            }

            else
            {
                canCraft.text = "Can Craft: No";
            }
        }*/
    }
}

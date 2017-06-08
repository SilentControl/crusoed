using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InfoCraftUI : MonoBehaviour {
    Text canCraft;
    Text description;
	Text reqToCraft;
    Text materials;
	// Use this for initialization
	void Start () {
		canCraft = transform.GetChild(0).GetComponent<Text>();
	    description = transform.GetChild(1).GetComponent<Text>();
		reqToCraft = transform.GetChild(2).GetComponent<Text>();
		materials = transform.GetChild(3).GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void clearText()
	{
		description.text = "";
		canCraft.text = "";
		reqToCraft.text = "";
		materials.text = "";		
	}

    public void updateSelectedItemInfo(Item craftable, bool enoughRes, bool selected)
    {
        if (selected == false)
        {
            description.text = "";
            canCraft.text = "";
			reqToCraft.text = "";
			materials.text = "";
        }

        else
        {
            CraftRecipe recipe = craftable.gameItemObject.GetComponent<CraftRecipe>();
			description.text = craftable.name + "\n" + craftable.description;
			reqToCraft.text = "Required to craft:";
			materials.text = "crafting place: ";

			switch (recipe.place)
			{
			case playerPlace.idle:
				materials.text += "-";
				break;
			case playerPlace.nearAnvil:
				materials.text += "near anvil";
				break;
			case playerPlace.nearBridge:
				materials.text += "near bridge";
				break;
			case playerPlace.nearFishSpot:
				materials.text += "near fishing spot";
				break;
			case playerPlace.nearRock:
				materials.text += "near rock";
				break;
			case playerPlace.nearTree:
				materials.text += "near tree";
				break;
			case playerPlace.onLitFirePlace:
				materials.text += "on lit fireplace";
				break;
			case playerPlace.onSpecialForge:
				materials.text += "on special forge";
				break;
			case playerPlace.onUnlitFirePlace:
				materials.text += "on unlit fireplace";
				break;
			case playerPlace.onWater:
				materials.text += "on water";
				break;
			default:
				break;
			}

			materials.text += "\n";

			for (int i = 0; i < recipe.requiredItems.Count; i++)
			{
				materials.text += recipe.requiredItems[i].name + ": " + recipe.requiredItems[i].quantity;
				materials.text += "\n";
			}
            
            if (enoughRes == true)
            {
                canCraft.text = "Can craft: Yes";
            }

            else
            {
                canCraft.text = "Can craft: No";
            }
        }
    }
}

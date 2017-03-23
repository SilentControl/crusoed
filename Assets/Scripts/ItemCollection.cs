using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCollection : MonoBehaviour {
    #region Singleton Code

    private static ItemCollection instance;
    public static ItemCollection Instance
    {
        get
        {
            if (instance == null)
                Debug.LogError("No instance in the scene!");
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Debug.LogError("Only one instance allowed!");
        }
    }
    #endregion

    public List<Item> Definitions = new List<Item>();

    private Dictionary<int, Item> itemDic;
    public Dictionary<int, Item> itemDictionary
    {
        get
        {
            // Definitions are never changed in game, so just copy references over once:
            if (itemDic == null)
            {
                itemDic = new Dictionary<int, Item>();
                foreach (Item item in Definitions) itemDic[item.getId()] = item;
            }
            return itemDic;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    Item[] mItems;
    public Text[] mItemNames;
    int mInventorySize = 5;
    // Start is called before the first frame update
    void Start()
    {
        mItems = new Item[mInventorySize];
        for (int i = 0; i < mInventorySize; i++)
        {
            mItemNames[i].text = "None";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToInventory(Item item)
    {
        for (int i = 0; i < mInventorySize; i++)
        {
            if (mItems[i] == null)
            {
                mItems[i] = item;
                mItemNames[i].text = item.name;
                return;
            }
        }
        Debug.Log("No room in inventory");
    }

    public void removeFromInventory(int index)
    {
        if (index < 0 || index >= mInventorySize)
        {
            return;
        }
        Debug.Log("Removing " + mItems[index].name + " from inventory");
        mItems[index] = null;
        mItemNames[index].text = "None";
    }

    // Not tested
    public Boolean inventoryHas(Item item)
    {
        for (int i = 0; i < mInventorySize; i++)
        {
            if (mItems[i] == item)
            {
                return true;
            }
        }
        return false;
    }
}

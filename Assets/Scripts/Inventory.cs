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
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            switch (e.keyCode)
            {
                case KeyCode.Alpha1:
                    removeFromInventory(0);
                    break;
                case KeyCode.Alpha2:
                    removeFromInventory(1);
                    break;
                case KeyCode.Alpha3:
                    removeFromInventory(2);
                    break;
                case KeyCode.Alpha4:
                    removeFromInventory(3);
                    break;
                case KeyCode.Alpha5:
                    removeFromInventory(4);
                    break;
                default:
                    break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToInventory(Item item)
    {
        if (inventoryHas(item.mFriendlyName))
        {
            Debug.Log("I already have one of these");
            return;
        }
        for (int i = 0; i < mInventorySize; i++)
        {
            if (mItems[i] == null)
            {
                mItems[i] = item;
                mItemNames[i].text = item.mFriendlyName;
                return;
            }
        }
        Debug.Log("No room in inventory");
    }

    public void removeFromInventory(int index)
    {
        if (index < 0 || index >= mInventorySize || mItems[index] == null)
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

    public Boolean inventoryHas(string name)
    {
        for (int i = 0; i < mInventorySize; i++)
        {
            if (mItemNames[i].text.Equals(name))
            {
                return true;
            }
        }
        return false;
    }
}

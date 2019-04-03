using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    Item[] mItems;
    public String[] mItemNames;
    public Image[] mItemImages;
    int mInventorySize = 5;
    public Sprite mEmptyInventory;
    public GameObject mInventoryUI;
    public bool mCanDropItems = false;

    // Start is called before the first frame update
    void Start()
    {
        mInventoryUI.transform.position = new Vector3(Screen.width / 2 - (mInventoryUI.GetComponent<RectTransform>().rect.width /2), 6 * Screen.height / 7, 0);
        mItems = new Item[mInventorySize];
        for (int i = 0; i < mInventorySize; i++)
        {
            mItemNames[i] = "None";
            mItemImages[i].sprite = mEmptyInventory;
        }
    }
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && mCanDropItems)
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

    public bool addToInventory(Item item)
    {
        if (inventoryHas(item.mFriendlyName))
        {
            Debug.Log("I already have one of these");
            return false;
        }
        for (int i = 0; i < mInventorySize; i++)
        {
            if (mItemNames[i] == "None")
            {
                Debug.Log("Adding to an empty spot in the inventory");
                mItems[i] = item;
                mItemNames[i] = item.mFriendlyName;
                Debug.Log("About to create sprite");

                Sprite newSprite = Sprite.Create(item.getInventoryIcon(), new Rect(0, 0, 128, 128), new Vector2(0, 0));
                mItemImages[i].sprite = newSprite;
                mItemImages[i].color = Color.white;

                return true;
            }
        }
        Debug.Log("No room in inventory");
        return false;
    }

    public void removeFromInventory(int index)
    {
        if (index < 0 || index >= mInventorySize || mItems[index] == null)
        {
            return;
        }
        Debug.Log("Removing " + mItems[index].name + " from inventory");
        mItems[index] = null;
        mItemNames[index] = "None";
        mItemImages[index].sprite = mEmptyInventory;
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
            if (mItemNames[i] == null)
            {
                continue;
            }
            if (mItemNames[i].Equals(name))
            {
                return true;
            }
        }
        return false;
    }
}

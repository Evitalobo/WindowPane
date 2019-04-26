using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// This class will know what the mouse is pointing at and when it is pressed.
public class MouseManager : MonoBehaviour {

    public Image mCursorImage;
    public Sprite mOpenHand;
    public Sprite mClosedHand;
    public Sprite mCursorSprite;
    public GameObject[] mFullScreenItems;
    GameObject ItemWithScreenOpen;
	// Use this for initialization
	void Start () {
        mCursorImage = mCursorImage.GetComponent<Image>();
        mFullScreenItems = GameObject.FindGameObjectsWithTag("FullScreenItem");
	}
	
	// Update is called once per frame
	void Update () {

        // Is the mouse over a UI object?
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        // Gathers info about what the mouse is over
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        foreach (GameObject Item in mFullScreenItems) {
            if (Item.GetComponent<FullScreenItem>().displayingImage == true) {
                ItemWithScreenOpen = Item;
            }
        }

        if (ItemWithScreenOpen != null && ItemWithScreenOpen.GetComponent<FullScreenItem>().displayingImage == false) {
            ItemWithScreenOpen = null;
        }

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.transform.gameObject;

            // Debug.Log("raycast hit something: " + ourHitObject.name);
            if (ItemWithScreenOpen != null) 
            {
                mouseOverItem(ItemWithScreenOpen.GetComponent<FullScreenItem>());
            } else if (ourHitObject.GetComponent<Item>() != null)
            {
                mouseOverItem(ourHitObject.GetComponent<Item>());
            } else if (ourHitObject.GetComponentInParent<Item>() != null)
            {
                mouseOverItem(ourHitObject.GetComponentInParent<Item>());
            } else
            {
                setCursorSprite(mCursorSprite);
            }

        } else
        {
            setCursorSprite(mCursorSprite);
        }

    }

    private void setCursorSprite(Sprite theSprite)
    {
        if (mCursorImage.sprite != theSprite)
        {
            mCursorImage.overrideSprite = theSprite;
            mCursorImage.sprite = theSprite;
        }
    }

    //void mouseOverItem(GameObject ourHitObject)
    //{
    //    cursorImage.color = Color.cyan;
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Debug.Log("Trying to interact with " + ourHitObject.name);
    //        ourHitObject.GetComponent<Item>().interact();
    //    }
    //}

    void mouseOverItem(Item item)
    {
        if (Input.GetMouseButton(0))
        {
            setCursorSprite(mClosedHand);
        } else
        {
            setCursorSprite(mOpenHand);
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            print("yay clicked on something");
            item.interact();
        }
    }
}

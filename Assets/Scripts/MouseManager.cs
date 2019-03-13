using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


// This class will know what the mouse is pointing at and when it is pressed.
public class MouseManager : MonoBehaviour {

    Image cursorImage;
	// Use this for initialization
	void Start () {
        cursorImage = GameObject.Find("CursorImage").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        // Is the mouse over a UI object?
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Gathers info about what the mouse is over
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.transform.gameObject;

            // Debug.Log("raycast hit something: " + ourHitObject.name);
            if (ourHitObject.GetComponent<Item>() != null)
            {
                mouseOverItem(ourHitObject.GetComponent<Item>());
            } else if (ourHitObject.GetComponentInParent<Item>() != null)
            {
                mouseOverItem(ourHitObject.GetComponentInParent<Item>());
            } else
            {
                cursorImage.color = Color.white;
            }

        } else
        {
            cursorImage.color = Color.white;
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
        cursorImage.color = Color.cyan;
        if (Input.GetMouseButtonUp(0))
        {
            print("yay clicked on something");
            item.interact();
        }
    }
}

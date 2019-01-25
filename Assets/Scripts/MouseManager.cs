using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// This class will know what the mouse is pointing at and when it is pressed.
public class MouseManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
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
            GameObject ourHitObject = hitInfo.collider.transform.gameObject;

            //Debug.Log("raycast hit something: " + ourHitObject.name);
            if (ourHitObject.GetComponent<Item>() != null)
            {
                mouseOverItem(ourHitObject.GetComponent<Item>());
            } else if (ourHitObject.GetComponentInParent<Item>() != null)
            {
                mouseOverItem(ourHitObject.GetComponentInParent<Item>());
            }

        }

    }

    void mouseOverItem(GameObject ourHitObject)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Trying to interact with " + ourHitObject.name);
            ourHitObject.GetComponent<Item>().interact();
        }
    }

    void mouseOverItem(Item item)
    {
        if (Input.GetMouseButtonDown(0))
        {
            item.interact();
        }
    }
}

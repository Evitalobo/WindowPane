using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
            GameObject ourHitObject;
            if (hitInfo.collider.transform.parent != null) {
                ourHitObject = hitInfo.collider.transform.parent.gameObject;
            } else
            {
                ourHitObject = hitInfo.collider.transform.gameObject;
            }
            Debug.Log("raycast hit something: " + ourHitObject.name);

            if (ourHitObject.GetComponent<Item>() != null)
            {
                mouseOverItem(ourHitObject);
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
}

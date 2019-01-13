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

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        //Gathers info about what the mouse is over
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            GameObject ourHitObject = hitInfo.collider.transform.parent.gameObject;
            //Debug.Log("raycast hit something: " + hitInfo.collider.transform.parent.name);

            if (ourHitObject.GetComponent<Item>() != null)
            {
                mouseOverItem(ourHitObject);
            }

        }

    }

    void mouseOverItem(GameObject ourHitObject)
    {

    }
}

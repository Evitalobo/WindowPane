using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 15.0f;
    public Text dialogueUI;
    public bool trip = false;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        dialogueUI.text = "Lately I've been having nightmares where I've been trapped inside my house and see figures and shapes that morph into each other.";

    }
	
	// Update is called once per frame
	void Update () {

        float moveForwardBack = Input.GetAxis("Vertical") * moveSpeed;
        float moveToSide = Input.GetAxis("Horizontal") * moveSpeed;
        moveForwardBack *= Time.deltaTime;
        moveToSide *= Time.deltaTime;
        transform.Translate(moveToSide, 0, moveForwardBack);
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
	}

    public void Drink()
    {
        trip = true;
        Debug.Log("trip = " + trip);
    }
}

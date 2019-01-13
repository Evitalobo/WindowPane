using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float moveSpeed = 15.0f;
    public Text dialogueUI;
    public bool trip = false;

	// Use this for initialization
	void Start () {
        Cursor.lockState = CursorLockMode.Locked;
        dialogueUI.text = "This room seems like a flipped version of the room in my dream. Almost all the furniture in my room was in the dream except for the TV and the cat. It's strange how your mind builds dreams based off of your perception of reality. What really is real?";

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

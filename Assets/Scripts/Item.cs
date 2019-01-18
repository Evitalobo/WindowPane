using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public bool flashlight = false;
    public bool glass = false;
    public bool water = false;
    public bool sink = false;
    public Text dialogueUI;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void interact()
    {
        Destroy(this);
    }
}

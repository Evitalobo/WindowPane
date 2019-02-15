using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Item {

    public string mLockedDoorText;

	// Use this for initialization
	void Start () {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        mDialogueUI = GameObject.Find("DialogueUI").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void interact()
    {
        if (mClassManager.inventoryHas("Keys"))
        {
            this.GetComponent<AudioSource>().PlayOneShot(interactSound);
            mClassManager.endGame();
        } else
        {
            mDialogueUI.text = mLockedDoorText;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : Item {

    public string mLockedDoorText;
    public int mDoorState;
    Vector3 rotateVector = new Vector3(-8.5f, 9.73f, 16.31f);
    float rotateAmount = 0;

	// Use this for initialization
	void Start () {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        // mDialogueUI = GameObject.Find("DialogueUI").GetComponent<Text>();
        mBubbleContainer = GameObject.Find("MainBubble");
        mBubble = mBubbleContainer.GetComponentInChildren<Canvas>();
        bubbleOrigin = GameObject.Find("BubbleOrigin").GetComponent<Transform>();
        mDialogueUI = mBubble.transform.Find("Text").GetComponent<Text>();
        mLockedDoorText = "It's locked. Are there keys anywhere?";
        mDoorState = 0; //0 for closed, 1 for opening, 2 for open
    }
	
	// Update is called once per frame
	void Update () {
        if (mCoolDown > 0)
        {
            mCoolDown--;
        }
        if(mDoorState == 1) {
            rotateAmount += 90 * Time.deltaTime;
            transform.RotateAround(rotateVector, Vector3.up, 90 * Time.deltaTime);
            if(rotateAmount >= 90) {
                mDoorState = 2;
            }
        } else {

        }		
	}

    public override void interact()
    {
        if (mCoolDown != 0)
        {
            Debug.Log("Cooldown not ready");
            return;
        }
        mCoolDown = 20;
        if (mBubbleContainer.transform.position != this.transform.position) {
            if(displayingMessage == true) {
                displayBubble();
            }
        }
        if (mClassManager.inventoryHas("Keys"))
        {
            mDialogueText = "I wonder why they'd hide the keys in a candle...";
            mDialogueUI.text = mDialogueText;
            if(mDoorState == 0) {
                this.GetComponent<AudioSource>().Play();
            }            
            //mClassManager.endGame();
            if(mDoorState == 0) {
                mDoorState = 1;
            }
            displayBubble();

        } else
        {
            mDialogueUI.text = mLockedDoorText;
            displayBubble();
        }
    }
}

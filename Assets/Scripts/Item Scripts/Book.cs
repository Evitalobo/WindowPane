using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : StoryItem
{

    void Start()
    {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        mBubbleContainer = GameObject.Find("MainBubble");
        mBubble = mBubbleContainer.GetComponentInChildren<Canvas>();
        bubbleOrigin = GameObject.Find("BubbleOrigin").GetComponent<Transform>();
        mDialogueUI = mBubble.transform.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mCoolDown > 0)
        {
            mCoolDown--;
        }
    }

    public override void interact()
    {
        if (mCoolDown != 0)
        {
            Debug.Log("Cooldown not ready");
            return;
        }
        if (mBubbleContainer.transform.position != this.transform.position) {
            if(displayingMessage == true) {
                displayBubble();
            }
        }
        mCoolDown = 20;
        if(checkState() == 0) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "Why's there a law textbook here?";
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "I have noooooo idea what any of this means...";
                displayBubble();
            }
        } else if(checkState() == 1) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "Why's there a law textbook here?";
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "I have noooooo idea what any of this means...";
                displayBubble();
            }
        } else if(checkState() == 2) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "It is against the law to build a bomb... 15-50 years in prison... Why are there instructions on how to make a bomb in this?!";
                setBook();
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "I have noooooo idea what any of this means...";
                displayBubble();
            }
        }
    }
}

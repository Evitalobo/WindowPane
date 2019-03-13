using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatClock : StoryItem
{    
    // Start is called before the first frame update

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
        mCoolDown = 20;
        if(checkState() == 0) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "-passage of time stuff placeholder-";
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "Meow. I like news. Do you like news? News is good. You should read the news. Read the news... News! ... Sounds like mews. I'm a cat.";
                changeState(1);
                displayBubble();
            }
        } else if(checkState() == 1) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "What the hell was that...";
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "Meow. I like news. Do you like news? News is good. You should read the news. Read the news... News! ... Sounds like mews. I'm a cat.";
                displayBubble();
            }
        } else if(checkState() == 2) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "What the hell was that...";
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "Meowww... I'm getting hungry. I hear a rat! You should bring me that rat. Or I might explode! Maybe...";                
                displayBubble();
                changeState(3);
            }
        } else if(checkState() == 3) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "What the hell was that...";
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "Meowww... I'm getting hungry. I hear a rat! You should bring me that rat. Or I might explode! Maybe...";                
                displayBubble();
            }
        } 

    }
}

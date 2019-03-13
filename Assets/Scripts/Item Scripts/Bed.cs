using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bed : StoryItem
{    
    // Start is called before the first frame update

    void Start()
    {
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

        if(checkState() < 2) {
            mDialogueUI.text = "Hmm, Thumb looks like he hasn't had food all day. I should feed him before I go to bed.";

            displayBubble();
        } else {
            mDialogueUI.text = "I remember reading about a bombing today, I should probably look more into that before I fall into my bed.";

            displayBubble();
        }

    }

}

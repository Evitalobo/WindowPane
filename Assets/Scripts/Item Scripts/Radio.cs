using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Radio : StoryItem
{    
    // Start is called before the first frame update
    public int mCurrentInteraction;
    public int mHeardConversation;
    public Sprite mResponseBubble;
    public Image mBubbleSelector;

    void Start()
    {
        mBubbleContainer = GameObject.Find("MainBubble");
        mBubble = mBubbleContainer.GetComponentInChildren<Canvas>();
        bubbleOrigin = GameObject.Find("BubbleOrigin").GetComponent<Transform>();
        mDialogueUI = mBubble.transform.Find("Text").GetComponent<Text>();     
        mCurrentInteraction = 0;
        mHeardConversation = 0;
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
        if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
            if(mHeardConversation == 0) {
                mDialogueUI.text = "I wonder if there’s anything else I could listen to other than the default trial message...";
            } else {
                mDialogueUI.text = "Sounds like a lot of commotion. Does anything seem off?";
            }
            displayBubble();
        } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
            mHeardConversation = 1;
            switch (mCurrentInteraction) {
                case 0: 
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "Don't forget to take your medicine and drink your water. It is all part of the plan.";
                mCurrentInteraction++;
                break;

                case 2: 
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "*radio static*";
                mCurrentInteraction++;
                break;

                case 4:                
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "two zero four eight six three";
                mCurrentInteraction++;
                break; 

                case 6: 
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "*radio static*";
                mCurrentInteraction++;
                break;

                case 8:                
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "Those who serve their government best do so without even realizing.";
                mCurrentInteraction++;
                break; 

                case 10: 
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "*radio static*";
                mCurrentInteraction++;
                break;

                case 12:                
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "To serve your government, you don't always have to be <b>lawful</b>.";  
                mHeardConversation = 2;              
                break;                 

                default:                 
                mCurrentInteraction++;
                break;
            }
            displayBubble();
        }       
    }    

}
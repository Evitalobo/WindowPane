using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatClock : StoryItem
{    
    // Start is called before the first frame update
    public int mCurrentInteraction;
    public Sprite mPlayerBubble;
    public Sprite mResponseBubble;
    public Image mBubbleSelector;
    public int mHeardConversation;
    [SerializeField] int mConvoIndex;

    void Start()
    {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
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

        if (mBubbleContainer.transform.position != this.transform.position) {
            if(displayingMessage == true) {
                displayBubble();
            }
        }

        if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
            if(checkState() == 0) {
                mDialogueUI.text = "Tic toc";
            } else {
                mDialogueUI.text = "Sounds like a lot of commotion. Does anything seem off?";
            }
            displayBubble();
        } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
            if(mHeardConversation == 0) {
                mHeardConversation = 1;
            }
            switch (mCurrentInteraction) {
                case 0: 
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "Rat in the Trap! We have another rat in the trap.";
                changeState(1);
                mCurrentInteraction++;
                break;

                case 2: 
                mBubbleSelector.sprite = mPlayerBubble;
                mDialogueUI.text = "He-hello? Are… are you talking to me?";
                mCurrentInteraction++;
                break;

                case 4:                
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "Why, yes!";
                mCurrentInteraction++;
                break; 

                case 6: 
                mBubbleSelector.sprite = mPlayerBubble;
                mDialogueUI.text = "I think... <size=10>I think I’m going crazy...</size>";
                mCurrentInteraction++;
                break;

                case 8:                
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "Don’t be silly. You’re sane, I’m sane, we’re <i>all</i> sane here!";
                mCurrentInteraction++;
                break; 

                case 10: 
                mBubbleSelector.sprite = mPlayerBubble;
                mDialogueUI.text = "What... Who are you?";
                mCurrentInteraction++;
                break;

                case 12:                
                mBubbleSelector.sprite = mResponseBubble;
                mDialogueUI.text = "<i>I'm</i> just a cat! <i>You're</i> just another <i>rat</i> in the <i>trap</i> who will soon go <i>splat</i>!";
                mCurrentInteraction++;
                break; 

                case 14: 
                mBubbleSelector.sprite = mPlayerBubble;
                mDialogueUI.text = "...Forget it. What is this place? I thought this was just a thing where they tested the effects of some aspirin substitute!?";
                mCurrentInteraction++;
                break;

                case 16:                
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "Oh, don't fret. This is still a test...";
                    mCurrentInteraction++;
                break; 

                case 18: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "How do I get out of here?";
                    mCurrentInteraction++;
                break;

                case 20:                
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "I do so enjoy talking to you! Oh, please stay a while longer!";
                    mCurrentInteraction++;
                break; 

                case 22: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "I'm getting nowhere here...";
                    mCurrentInteraction++;
                break;

                case 24: 
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "If you want to get out of here, you're gonna have to be a <b>copy-cat</b>.";
                    // mClassManager.stopTripping();
                    mClassManager.HadConvo(mConvoIndex);
                    changeState(2);
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

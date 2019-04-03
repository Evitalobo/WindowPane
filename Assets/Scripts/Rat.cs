using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Item script
public class Rat : StoryItem {

    public GameObject mDoor;

    public int mCurrentInteraction;
    public int mHeardConversation;
    public Sprite mResponseBubble;
    public Sprite mPlayerBubble;
    public Image mBubbleSelector;

    // Use this for initialization
    void Start () {

        mCoolDown = 0;
        if (mFriendlyName == "")
        {
            mFriendlyName = this.name;
        }
        source = this.GetComponent<AudioSource>();
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        mBubbleContainer = GameObject.Find("MainBubble");
        mBubble = mBubbleContainer.GetComponentInChildren<Canvas>();
        bubbleOrigin = GameObject.Find("BubbleOrigin").GetComponent<Transform>();
        // mDialogueUI = GameObject.Find("DialogueUI").GetComponent<Text>();
        mDialogueUI = mBubble.transform.Find("Text").GetComponent<Text>();
        mBubble.enabled = false;
        mCurrentInteraction = 0;
        mHeardConversation = 0;

    }
    
    // Update is called once per frame
    void Update () {
        if (mCoolDown > 0)
        {
            mCoolDown--;
        }

        if(source.isPlaying == false){
            if(mDoor.GetComponent<Door>().mDoorState != 0) {
                source.Play();
            }
        }
    }

    // This method can be overridden by a class that extends the Item class
    public override void interact()
    {        
        Debug.Log("rat test");
        if (mCoolDown != 0)
        {
            return;
        }
        mCoolDown = 20;
        if (!mClassManager.AllWordsFound())
        {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {                
                mBubbleSelector.sprite = mResponseBubble;
                if(mHeardConversation == 0) {
                    mDialogueUI.text = "Apparently he's been fed already, that's good.";
                } else {
                    mDialogueUI.text = "Sounds like a lot of commotion. Does anything seem off?";
                }
                displayBubble();
            } else {
                if(mHeardConversation == 0) {
                    mHeardConversation = 1;
                }
                switch (mCurrentInteraction) {
                    case 0: 
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "Squeak squeak, brother.";
                    mCurrentInteraction++;
                    break;

                    case 2: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "What?";
                    mCurrentInteraction++;
                    break;

                    case 4:                
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "I mean, hello! How'd you end up here?";
                    mCurrentInteraction++;
                    break; 

                    case 6: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "They offered to pay me a month's rent.";
                    mCurrentInteraction++;
                    break;

                    case 8:                
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "Seriously? I didn't get anything but food for this.";
                    mCurrentInteraction++;
                    break; 

                    case 10: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "I... don't think they really have to pay you.";
                    mCurrentInteraction++;
                    break;

                    case 12:                
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "Why wouldn't they have to pay me? I'm stuck here too, aren't I?";
                    mCurrentInteraction++;
                    break; 

                    case 14: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "Well... you're a rat.";
                    mCurrentInteraction++;
                    break;

                    case 16:                
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "And you're some sort of monkey, what's the difference?";
                    mCurrentInteraction++;
                    break; 

                    case 18: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "They didn't ask you to be here. They just trapped you and stuck you here.";
                    mCurrentInteraction++;
                    break;

                    case 20:                
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "Well, Mr. Superior, don't you feel trapped? Can you leave any time you like?";
                    mCurrentInteraction++;
                    break; 

                    case 22: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "Look, I'm just waiting for the payoff at the end, when they'll let me out. I could walk out right now if I wanted, but I'm <i>choosing</i> not to.";
                    mCurrentInteraction++;
                    break;

                    case 24: 
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "Oh really? Could just break on out of here, could you? I'd like to see it, friend. Like it or not, we're trapped here until they finish their test. All we can do is hope we like the results.";
                    mCurrentInteraction++;
                    break; 

                    case 26: 
                    mBubbleSelector.sprite = mPlayerBubble;
                    mDialogueUI.text = "I mean, it's just a test for an aspirin substitute. What's the worst that could happen?";
                    mCurrentInteraction++;
                    break;

                    case 28: 
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "Oh, aspirin substitute, is it? Feel like one to you? This ain't no clinical trial, this is a psychological experiment, a capital T-- <b>Test</b>. Squeak squeak, buddy. Squeak squeak.";
                    mHeardConversation = 2;
                    mCurrentInteraction++;
                    break; 

                    case 30:
                    mBubbleSelector.sprite = mResponseBubble;
                    mDialogueUI.text = "This ain't no clinical trial, this is a psychological experiment, a capital T-- <b>Test</b>.";
                    break;

                    default:                 
                    mCurrentInteraction++;
                    break;
                }
                displayBubble();
            }       
        } else {
            SceneManager.LoadScene(2);
        }
        //dream state 
    }
}

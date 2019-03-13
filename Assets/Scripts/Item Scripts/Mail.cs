using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mail : FullScreenItem
{
    bool needImage;
    bool gaveImage;
    bool needReset;

    void Start()
    {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        mBubbleContainer = GameObject.Find("MainBubble");
        mBubble = mBubbleContainer.GetComponentInChildren<Canvas>();
        bubbleOrigin = GameObject.Find("BubbleOrigin").GetComponent<Transform>();
        mDialogueUI = mBubble.transform.Find("Text").GetComponent<Text>();        
        mImageContainer = GameObject.Find("PictureBubble");
        mImage = mImageContainer.GetComponentInChildren<Canvas>();        
        imageOrigin = GameObject.Find("ImageOrigin").GetComponent<Transform>();
        mImage.enabled = false;  
        needImage = false;
        gaveImage = false; 
        needReset = false;
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
                Debug.Log("hi");
                mDialogueUI.text = "Just a bunch of spam mail...";
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "Nooo amount of tripping could make this stuff interesting...";
                displayBubble();
            }
        } else if(checkState() == 1) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "Just a bunch of spam mail...";
                displayBubble();
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "Nooo amount of tripping could make this stuff interesting...";
                displayBubble();
            }
        } else if(checkState() == 2) {
            if(mPlayer.GetComponent<PlayerController>().mTrip == false) {
                mDialogueUI.text = "This pamphlet... Explosive fashion... What's this card doing in here?";
                setMail();
                if(displayingMessage == true){
                    if(gaveImage == false) {
                        needImage = true;
                        displayImage();
                        displayBubble();
                    } else {
                        displayBubble();
                    }
                } else if(needReset == true) {
                    needReset = false;
                    gaveImage = false;
                    displayBubble();
                } else if(displayingImage == true) {
                    displayImage();
                    needReset = true;
                } else {
                    displayBubble();
                }              
            } else if(mPlayer.GetComponent<PlayerController>().mTrip == true) {
                mDialogueUI.text = "Nooo amount of tripping could make this stuff interesting...";
                displayBubble();
            }
        }
    }

    public override void displayImage() {
        mImageContainer.transform.position = this.transform.position;
        if (mImage.enabled == false)
        {
            mImage.enabled = true;
        }           

        if (displayingImage == false)
        {
            if(needImage == true) {
                Debug.Log("Opening image bubble");
                needImage = false;
                //mBubble.transform.localScale = new Vector3(0.52933f, 0.52933f, 0.52933f);
                imageSelector.sprite = Image;
                mImage.GetComponent<Animator>().Play("BubbleOpen");
                displayingImage = true;
                gaveImage = true;
            }
            else {
                Debug.Log("Closing message bubble");
                displayBubble();
            } 
        }
        else
        {
            Debug.Log("Closing image");
            mImage.GetComponent<Animator>().Play("BubbleClose");
            //mBubble.enabled = false;
            displayingImage = false;  
            mDialogueUI.text = "I don't think that's that far from here, but why?";         
            displayBubble();
        }
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newspaper : FullScreenItem
{

    public Sprite spriteState0;
    public Sprite spriteState1;

    // Start is called before the first frame update
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
        Debug.Log("Using full screen item interact");        
        if(checkState() == 0)
        {
            imageSelector.sprite = spriteState0;
        } else
        {
            imageSelector.sprite = spriteState1;
            changeState(2);
        }
        displayImage();

    }

    public void displayImage()
    {
        mImageContainer.transform.position = this.transform.position;
        if (mImage.enabled == false)
        {
            mImage.enabled = true;
        }           

        if (displayingImage == false)
        {
            if(displayingMessage == true){
                Debug.Log("Closing message bubble");
                displayBubble();
            } else {
                Debug.Log("Opening image bubble");
                //mBubble.transform.localScale = new Vector3(0.52933f, 0.52933f, 0.52933f);
                mImage.GetComponent<Animator>().Play("BubbleOpen");
                displayingImage = true;
            }
        }
        else
        {
            Debug.Log("Closing image");
            mImage.GetComponent<Animator>().Play("BubbleClose");
            //mBubble.enabled = false;
            displayingImage = false;
            if (mClassManager.IsTripping() && mTrippingDialogueText != "")
            {
                displayBubble();
        
                mDialogueUI.text = mTrippingDialogueText;
            } else if (mDialogueText != "")
            {
                displayBubble();
       
                mDialogueUI.text = mDialogueText;
            }
        }
    }

    public void displayBubble()
    {
        mBubbleContainer.transform.position = this.transform.position;
        if (mBubble.enabled == false)
        {
            mBubble.enabled = true;
        }
            

        if (displayingMessage == false)
        {
            Debug.Log("Opening bubble");
            //mBubble.transform.localScale = new Vector3(0.52933f, 0.52933f, 0.52933f);
            mBubble.GetComponent<Animator>().Play("BubbleOpen");
            displayingMessage = true;
        }
        else
        {
            Debug.Log("Closing bubble");
            mBubble.GetComponent<Animator>().Play("BubbleClose");
            //mBubble.enabled = false;
            displayingMessage = false;
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryItem : Item
{    
    public GameObject mPlayer;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void interact()
    {   

    }

    public int checkState()
    {
        return mPlayer.GetComponent<PlayerController>().mGameState;
    }

    public bool checkBook() 
    {
        return mPlayer.GetComponent<PlayerController>().mBookState;
    }

    public bool checkMail() 
    {
        return mPlayer.GetComponent<PlayerController>().mMailState;
    }

    public bool checkRat() 
    {
        return mPlayer.GetComponent<PlayerController>().mRatState;
    }

    public void setBook()
    {
        mPlayer.GetComponent<PlayerController>().mBookState = true;
        return;
    }

    public void setMail()
    {
        mPlayer.GetComponent<PlayerController>().mMailState = true;
        return;
    }

    public void setRat()
    {
        mPlayer.GetComponent<PlayerController>().mRatState = true;
        return;
    }

    public void changeState(int changeTo)
    {
        mPlayer.GetComponent<PlayerController>().mGameState = changeTo;
        return;
    }

    public void displayBubble()
    {
        mBubbleContainer.transform.position = this.transform.position;
        if (mBubbleContainer.transform.position != this.transform.position) {
            if(displayingMessage == true) {
                displayBubble();
            }
        }
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

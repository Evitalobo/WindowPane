using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Item script
public class Rat : StoryItem {

    public GameObject mDoor;

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
        if (!mClassManager.AllWordsFound())
        {
            Debug.Log("Can't load new scene, I haven't found all the words yet!");
            return;
        }
        Debug.Log("rat test");
        if (mCoolDown != 0)
        {
            return;
        }
        mCoolDown = 20;
   
        SceneManager.LoadScene(2);
        //dream state
    }
}

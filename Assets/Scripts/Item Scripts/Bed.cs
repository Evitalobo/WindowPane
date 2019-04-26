using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bed : StoryItem
{    
    // Start is called before the first frame update

    void Start()
    {
        mClassManager = ClassManager.mClassManager;
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

        if(!mClassManager.AllConvosHad()) {
            if (mClassManager.IsTripping())
            {
                mDialogueUI.text = "I'm not tired yet, I should check out the apartment more.";
            } else
            {
                mDialogueUI.text = "I'm thirsty, I should get some water before bed.";
            }

            displayBubble();
        } else {
            mClassManager.changeStoryState(PuzzleManager.storyState.dreamState);
            SceneManager.LoadScene("DreamState", LoadSceneMode.Single);
        }

    }

}

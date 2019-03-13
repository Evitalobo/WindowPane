using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.UI;

public class Water : Item
{

    public int potency;
    public bool mNeedGlass;
    public string noGlass;
    public string noPills;

    // These are what will be checked for in the inventory.
    string mGlassName = "Glass";
    string mPillsName = "Pills";


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
        if (mBubbleContainer.transform.position != this.transform.position) {
            if(displayingMessage == true) {
                displayBubble();
            }
        }
        Debug.Log("Adding " + potency + " to trip amount");
        if (interactSound != null && !mClassManager.IsTripping())
        {
            if (!mNeedGlass || mClassManager.inventoryHas(mGlassName)) {
                source.PlayOneShot(interactSound, 0.5f);
            }
        } else if (trippingInteractSound != null && mClassManager.IsTripping())
        {
            if (!mNeedGlass || mClassManager.inventoryHas(mGlassName)) {
                source.PlayOneShot(interactSound, 0.5f);
            }
        }
        if (mClassManager.IsTripping())
        {
            mDialogueUI.text = mTrippingDialogueText;
            displayBubble();
        } else
        {
            mDialogueUI.text = mDialogueText;
            displayBubble();
            if (mNeedGlass && !mClassManager.inventoryHas(mGlassName))
            {
                mDialogueUI.text += noGlass;
            } else if (!mClassManager.inventoryHas(mPillsName))
            {
                mDialogueUI.text += noPills;
            }
        }
        if (!mNeedGlass || mClassManager.inventoryHas(mGlassName)) {
            mClassManager.increaseTrip(potency);
        }
    }
}

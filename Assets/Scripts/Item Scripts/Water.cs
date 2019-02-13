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
        mDialogueUI = GameObject.Find("DialogueUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact()
    {
        Debug.Log("Adding " + potency + " to trip amount");
        if (mClassManager.IsTripping())
        {
            mDialogueUI.text = mTrippingDialogueText;
        } else
        {
            mDialogueUI.text = mDialogueText;
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

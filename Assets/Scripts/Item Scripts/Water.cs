﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : Item
{

    public int potency;

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
        }
        mClassManager.increaseTrip(potency);
    }
}

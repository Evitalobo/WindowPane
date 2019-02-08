using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public bool mTakeable;
    public Text mDialogueUI;
    public ClassManager mClassManager;
    public string mDialogueText;
    public string mTrippingDialogueText;
    public bool flashlight;
    public bool water;
    public bool sink;
    public bool Sink;
    public bool glass;
    public bool MatchBox;
    public bool pillContainer;

	// Use this for initialization
	void Start () {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        mDialogueUI = GameObject.Find("DialogueUI").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    // This method can be overridden by a class that extends the Item class
    public virtual void interact()
    {
        Debug.Log("Using item interact");
        if (mClassManager.IsTripping())
        {
            mDialogueUI.text = mTrippingDialogueText;
        } else
        {
            mDialogueUI.text = mDialogueText;
        }
        
        if (mTakeable)
        {
            mClassManager.addToInventory(this);
        }
    }
}

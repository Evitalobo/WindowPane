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
    public string mFriendlyName;


	// Use this for initialization
	void Start () {
        if (mFriendlyName == "")
        {
            mFriendlyName = this.name;
        }
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

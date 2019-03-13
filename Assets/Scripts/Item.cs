using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Item script
public class Item : MonoBehaviour {

    public bool mTakeable;
    public Text mDialogueUI;
    public ClassManager mClassManager;
    public string mDialogueText;
    public string mTrippingDialogueText;
    public string mFriendlyName;
    public GameObject mPrefab;

    public GameObject mBubbleContainer;
    public Canvas mBubble;
    public Transform bubbleOrigin;

    public AudioClip interactSound;
    public AudioClip trippingInteractSound;
    public AudioSource source;
    private float volume = 1.0f;
    public Animator mAnimator;

    public bool displayingMessage = false;

    public int mCoolDown;


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
	}

    // This method can be overridden by a class that extends the Item class
    public virtual void interact()
    {
        if (mCoolDown != 0)
        {
            Debug.Log("Cooldown not ready");
            return;
        }
        mCoolDown = 20;
        //animation
        if (mAnimator)
        {
            mAnimator.Play("");
        }

        Debug.Log("Using item interact");
        if (mClassManager.IsTripping() && mTrippingDialogueText != "")
        {
            displayBubble();
            
            mDialogueUI.text = mTrippingDialogueText;
        } else if (mDialogueText != "")
        {
            displayBubble();
           
            mDialogueUI.text = mDialogueText;
        }

        if (interactSound != null && !mClassManager.IsTripping())
        {
            source.PlayOneShot(interactSound, volume);
        } else if (trippingInteractSound != null && mClassManager.IsTripping())
        {
            source.PlayOneShot(trippingInteractSound, volume);
        }

        if (mTakeable)
        {
            if (mClassManager.addToInventory(this))
            {
                Destroy(this.gameObject);
            }
            //Add component where item becomes smaller in scale and added to inventory
        }
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

    public GameObject getPrefab()
    {
        return mPrefab;
    }
}

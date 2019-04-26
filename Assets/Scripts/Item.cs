using System;
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

    public TextAsset mInventoryIconBytes;

    public GameObject mBubbleContainer;
    public Canvas mBubble;
    public Transform bubbleOrigin;

    public AudioClip interactSound;
    public AudioClip trippingInteractSound;
    public AudioSource source;
    public float mVolume = 1.0f;
    public Animator mAnimator;

    public event Action OnOver;             // Called when the gaze moves over this object
    public event Action OnOut;              // Called when the gaze leaves this object
    public event Action OnClick;            // Called when click input is detected whilst the gaze is over this object.
    public event Action OnDoubleClick;      // Called when double click input is detected whilst the gaze is over this object.
    public event Action OnUp;               // Called when Fire1 is released whilst the gaze is over this object.
    public event Action OnDown;             // Called when Fire1 is pressed whilst the gaze is over this object.

    protected bool m_IsOver;


    public bool IsOver
    {
        get { return m_IsOver; }              // Is the gaze currently over this object?
    }

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
        mClassManager = ClassManager.mClassManager;
        mBubbleContainer = GameObject.Find("MainBubble");
        mBubble = mBubbleContainer.GetComponentInChildren<Canvas>();
        bubbleOrigin = GameObject.Find("BubbleOrigin").GetComponent<Transform>();
        // mDialogueUI = GameObject.Find("DialogueUI").GetComponent<Text>();
        mDialogueUI = mBubble.transform.Find("Text").GetComponent<Text>();
        mBubble.enabled = false;

	}

    public virtual void OnEnable()
    {
        OnClick += interact;
    }

    public virtual void OnDisable()
    {
        OnClick -= interact;
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
                
        if (mBubbleContainer.transform.position != this.transform.position) {
            if(displayingMessage == true) {
                displayBubble();
            }
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
            source.PlayOneShot(interactSound, mVolume);
        } else if (trippingInteractSound != null && mClassManager.IsTripping())
        {
            source.PlayOneShot(trippingInteractSound, mVolume);
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

    public Texture2D getInventoryIcon()
    {
        Debug.Log("Returning 2d texture");
        Texture2D texture = new Texture2D(128, 128);
        texture.LoadImage(mInventoryIconBytes.bytes);
        return texture;
    }

    // The below functions are called by the VREyeRaycaster when the appropriate input is detected.
    // They in turn call the appropriate events should they have subscribers.
    public void Over()
    {
        m_IsOver = true;

        if (OnOver != null)
            OnOver();
    }


    public void Out()
    {
        m_IsOver = false;

        if (OnOut != null)
            OnOut();
    }


    public virtual void Click()
    {
        if (OnClick != null)
            OnClick();
    }


    public void DoubleClick()
    {
        if (OnDoubleClick != null)
            OnDoubleClick();
    }


    public void Up()
    {
        if (OnUp != null)
            OnUp();
    }


    public void Down()
    {
        if (OnDown != null)
            OnDown();
    }
}

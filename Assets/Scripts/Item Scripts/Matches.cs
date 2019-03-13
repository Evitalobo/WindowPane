using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Item script
public class Matches : MonoBehaviour
{

    public bool mTakeable;
    public Text mDialogueUI;
    public ClassManager mClassManager;
    public string mDialogueText;
    public string mTrippingDialogueText;
    public string mFriendlyName;

    public AudioClip interactSound;
    public AudioClip trippingInteractSound;
    public AudioSource source;
    private float volume = 1.0f;
    public GameObject Matchbox;


    // Use this for initialization
    void Start()
    {
        if (mFriendlyName == "")
        {
            mFriendlyName = this.name;
        }
        source = this.GetComponent<AudioSource>();
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        mDialogueUI = GameObject.Find("DialogueUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // This method can be overridden by a class that extends the Item class
    public virtual void interact()
    {
        Debug.Log("Using item interact");
        if (mClassManager.IsTripping() && mTrippingDialogueText != "")
        {
            mDialogueUI.text = mTrippingDialogueText;
        }
        else if (mDialogueText != "")
        {
            mDialogueUI.text = mDialogueText;
        }

        if (mTakeable)
        {
           // mClassManager.addToInventory(this);
            Matchbox.SetActive(true);
            Destroy(this);

        }

        if (interactSound != null && !mClassManager.IsTripping())
        {
            source.PlayOneShot(interactSound, volume);
        }
        else if (trippingInteractSound != null && mClassManager.IsTripping())
        {
            source.PlayOneShot(trippingInteractSound, volume);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Candle : Item
{

    bool lit = false;
    public string candleLitText;
    int lastShrinkTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        mBubbleContainer = GameObject.Find("MainBubble");
        mBubble = mBubbleContainer.GetComponentInChildren<Canvas>();
        bubbleOrigin = GameObject.Find("BubbleOrigin").GetComponent<Transform>();
        mDialogueUI = mBubble.transform.Find("Text").GetComponent<Text>();
        candleLitText = "Alright, it's lit! Is there something... inside the wax?";
    }

    // Update is called once per frame
    void Update()
    {
    	if (mCoolDown > 0)
        {
            mCoolDown--;
        }
        if (lit)
        {
            if (Mathf.Floor(Time.time) % 2 == 0 && Mathf.Floor(Time.time) != lastShrinkTime && this.gameObject.transform.localScale.y > 0.2)
            {
                lastShrinkTime = (int)Mathf.Floor(Time.time);
                this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z * 0.9f);
            }
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
        if (mClassManager.inventoryHas("Matches"))
        {
        	if(lit == false) {
        		this.GetComponent<AudioSource>().Play();
        	}
            mDialogueUI.text = candleLitText;
            lit = true;
            Destroy(this.GetComponent<Collider>());
            displayBubble();
        }
        else
        {
            mDialogueUI.text = "A candle? I need matches to light this.";
            displayBubble();
        }
    }
}

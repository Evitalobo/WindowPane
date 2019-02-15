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
        mDialogueUI = GameObject.Find("DialogueUI").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
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
        if (mClassManager.inventoryHas("Matches"))
        {
            mDialogueUI.text = candleLitText;
            lit = true;
            Destroy(this.GetComponent<Collider>());
        }
        else
        {
            mDialogueUI.text = "I need matches to light this";
        }
    }
}

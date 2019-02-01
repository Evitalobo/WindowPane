using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : Item
{

    public int potency;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact()
    {
        Debug.Log("Adding " + potency + " to trip amount");
        mDialogueUI.text = mDialogueText;
        mClassManager.increaseTrip(potency);
    }
}

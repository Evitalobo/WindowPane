using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : Item
{
    public string deskNeeds;
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
        if (mClassManager.inventoryHas(deskNeeds))
        {
            Debug.Log("Opened desk");
        } else
        {
            Debug.Log("I think this is locked");
        }
    }
}

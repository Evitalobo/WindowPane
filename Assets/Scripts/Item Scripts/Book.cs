﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : Item
{
    public ClassManager mClassManager;
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
        Debug.Log("using book interact");
        mClassManager.addToInventory(this);
        return;
    }
}

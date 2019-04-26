using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Item
{

    
    // Start is called before the first frame update
    void Start()
    {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void interact()
    {
        mClassManager.addToInventory(this);
        
    }
}

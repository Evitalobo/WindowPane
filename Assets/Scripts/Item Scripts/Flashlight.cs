using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : Item
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
        mClassManager.addToInventory(this);
        Destroy(this.gameObject);
    }
}

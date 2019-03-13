using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word : Item
{

    public int mIndex;

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
        mClassManager.foundWord(mIndex);
        Destroy(this.gameObject);
    }
}

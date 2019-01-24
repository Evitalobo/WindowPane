using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class will have references to other classes and methods for them to communicate with one another.
// This is so every class doesn't have to have a reference to every other class, they can all communicate
// through here for organization and readability's sake.
public class ClassManager : MonoBehaviour
{

    public MouseManager mMouseManager;
    public Inventory mInventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addToInventory(Item item)
    {
        mInventory.addToInventory(item);
    }
}

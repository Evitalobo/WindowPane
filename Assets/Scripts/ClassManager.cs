using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class will have references to other classes and methods for them to communicate with one another.
// This is so every class doesn't have to have a reference to every other class, they can all communicate
// through here for organization and readability's sake.
public class ClassManager : MonoBehaviour
{

    public MouseManager mMouseManager;
    public Inventory mInventory;
    public GameObject mPlayerCapsule;
    public PuzzleManager mPuzzleManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool addToInventory(Item item)
    {
        return mInventory.addToInventory(item);
    }

    public System.Boolean inventoryHas(string name)
    {
        return mInventory.inventoryHas(name);
    }

    public void increaseTrip(int amount)
    {
        mPlayerCapsule.GetComponent<PlayerController>().addTrip(amount);
    }

    public bool IsTripping()
    {
        return mPlayerCapsule.GetComponent<PlayerController>().IsTripping();
    }

    public void endGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);        
        
    }

    public bool AllWordsFound()
    {
        return mPuzzleManager.AllWordsFound();
    }

    public void foundWord(int index)
    {
        mPuzzleManager.foundWord(index);
    }
}

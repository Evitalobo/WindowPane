using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This class will have references to other classes and methods for them to communicate with one another.
// This is so every class doesn't have to have a reference to every other class, they can all communicate
// through here for organization and readability's sake.
public class ClassManager : MonoBehaviour
{

    public static ClassManager mClassManager;

    public MouseManager mMouseManager;
    public Inventory mInventory;
    public GameObject mPlayerCapsule;
    public PuzzleManager mPuzzleManager;
    bool mPaused;

    // Start is called before the first frame update
    void Awake()
    {
        mPaused = false;

        if (mClassManager == null)
        {
            mClassManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (mClassManager != null)
        {
            Destroy(this.gameObject);
        }

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
        if (mPlayerCapsule.GetComponent<PlayerController>())
            mPlayerCapsule.GetComponent<PlayerController>().addTrip(amount);
    }

    public void stopTripping()
    {
        if (mPlayerCapsule.GetComponent<PlayerController>())
            mPlayerCapsule.GetComponent<PlayerController>().stopTripping();
    }

    public void startTripping()
    {
        if (mPlayerCapsule.GetComponent<PlayerController>())
            mPlayerCapsule.GetComponent<PlayerController>().startTripping();
    }

    public bool IsTripping()
    {
        if (mPlayerCapsule.GetComponent<PlayerController>())
            return mPlayerCapsule.GetComponent<PlayerController>().IsTripping();
        return false;
    }

    public void endGame()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);        
        
    }

    public bool AllConvosHad()
    {
        return mPuzzleManager.AllConvosHad();
    }

    public void HadConvo(int index)
    {
        Debug.Log("Had convo: " + index);
        mPuzzleManager.hadConvo(index);
    }

    public bool paused()
    {
        return mPaused;
    }

    public void pause()
    {
        mPaused = true;
    }

    public void unpause()
    {
        mPaused = false;
    }

    public void changeStoryState(PuzzleManager.storyState state)
    {
        mPuzzleManager.changeStoryState(state);
    }
}

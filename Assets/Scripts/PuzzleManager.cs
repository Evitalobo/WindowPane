using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public static PuzzleManager mPuzzleManager;

    ClassManager mClassManager;
    public bool[] mConversationsHad;
    public int mNumConvos;

    public enum storyState
    {
        firstDay,
        dreamState,
        secondDay
    }

    [SerializeField] private storyState mStoryState;

    // Start is called before the first frame update
    void Awake()
    {
        
        
        if(mPuzzleManager == null)
        {
            mPuzzleManager = this;
            DontDestroyOnLoad(this.gameObject);
        } else if (mPuzzleManager != null)
        {
            Destroy(this.gameObject);
        }

        
    }

    private void Start()
    {
        mClassManager = ClassManager.mClassManager;
        mConversationsHad = new bool[mNumConvos];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void hadConvo(int index)
    {
        if (index < 0 || index >= mConversationsHad.Length)
        {
            Debug.Log("Index out of bounds in foundWord()");
            return;
        }
        mConversationsHad[index] = true;
    }

    public bool AllConvosHad()
    {
        for (int i = 0; i < mNumConvos; i++)
        {
            if (mConversationsHad[i] == false)
            {
                return false;
            }
        }
        return true;
    }

    public void changeStoryState(storyState state)
    {
        mStoryState = state;
    }

    public storyState getStoryState()
    {
        return mStoryState;
    }
}

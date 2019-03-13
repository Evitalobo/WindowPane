using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    ClassManager mClassManager;
    public bool[] mWordsFound;
    public int mNumWords;

    // Start is called before the first frame update
    void Start()
    {
        mClassManager = GameObject.Find("ClassManager").GetComponent<ClassManager>();
        mWordsFound = new bool[mNumWords];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void foundWord(int index)
    {
        if (index < 0 || index >= mWordsFound.Length)
        {
            Debug.Log("Index out of bounds in foundWord()");
            return;
        }
        mWordsFound[index] = true;
    }

    public bool AllWordsFound()
    {
        for (int i = 0; i < mNumWords; i++)
        {
            if (mWordsFound[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}

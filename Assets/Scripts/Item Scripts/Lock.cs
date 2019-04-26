using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : Item
{

    [SerializeField] private Vector3 mGrowScale;
    private Vector3 mNormalScale;
    PuzzleManager mPuzzleManager;
    [SerializeField] private PuzzleManager.storyState mActiveDay;
    // Start is called before the first frame update
    void Start()
    {
        mPuzzleManager = PuzzleManager.mPuzzleManager;
        if(mPuzzleManager.getStoryState() != mActiveDay)
        {
            this.gameObject.SetActive(false);
        }
        mNormalScale = this.gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        OnOver += grow;
        OnOut += shrink;
    }

    public void OnDisable()
    {
        OnOver -= grow;
        OnOut -= shrink;
    }

    private void grow()
    {
        this.gameObject.transform.localScale = mGrowScale;
    }

    private void shrink()
    {
        this.gameObject.transform.localScale = mNormalScale;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippyCamera : TripItem
{
    Camera mCamera;
    float mCycleCounter;
    // Start is called before the first frame update
    void Start()
    {
        mCamera = this.GetComponent<Camera>();
        mCycleCounter = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        mCycleCounter += 0.02f;
        if (mTripping)
        {
            mCamera.fieldOfView = (float) (10 * Math.Sin(mCycleCounter%10)) + 45;
        } else
        {
            mCamera.fieldOfView = 60;
        }
    }

    public override void startTrip()
    {
        mTripping = true;
    }

    public override void stopTrip()
    {
        mTripping = false;
    }
}
